using Project_PRN231_Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly string link = "http://localhost:5000/api/";
        private static User farmer = new User();
        private static List<CareProcess> listCare = new List<CareProcess>();
        private static List<HarvestProcess> listHarvest = new List<HarvestProcess>();
        private static List<PlantProcess> listPlant = new List<PlantProcess>();
        HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index(string keyword)
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                User u = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                string role = u.Role.RoleName;
                string odataQuery;
                HttpResponseMessage response;
                switch (role.ToLower())
                {
                    case "admin":
                        List<User> listUsers = new List<User>();
                        odataQuery = "?$filter= contains(Username, '" + keyword + "')&$expand=Role";
                        response = await _client.GetAsync(link + "User" + odataQuery);
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await response.Content.ReadAsStringAsync();
                            listUsers = JsonConvert.DeserializeObject<List<User>>(data);
                            ViewBag.Keyword = keyword;
                            ViewBag.list = listUsers;
                            return View();
                        }
                        break;
                    case "farmer":
                        listCare = new List<CareProcess>();
                        listHarvest = new List<HarvestProcess>();
                        listPlant = new List<PlantProcess>();
                        int uid = u.UserId;
                        odataQuery = uid + "?$expand=Role,CareProcesses,HarvestProcesses,PlantProcesses";
                        response = await _client.GetAsync(link + "User/" + odataQuery);
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await response.Content.ReadAsStringAsync();
                            farmer = JsonConvert.DeserializeObject<User>(data);
                            listCare = farmer.CareProcesses.ToList();
                            listHarvest = farmer.HarvestProcesses.ToList();
                            listPlant = farmer.PlantProcesses.ToList();

                            ViewBag.listCare = listCare;
                            ViewBag.listHarvest = listHarvest;
                            ViewBag.listPlant = listPlant;
                            return View();
                        }
                        break;
                    case "manager":
                        List<Crop> listCrops = new List<Crop>();
                        odataQuery = "?$filter= contains(CropName, '" + keyword + "')&$expand=CareProcesses,HarvestProcesses,PlantProcesses";
                        response = await _client.GetAsync(link + "Crop" + odataQuery);
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await response.Content.ReadAsStringAsync();
                            listCrops = JsonConvert.DeserializeObject<List<Crop>>(data);
                            ViewBag.Keyword = keyword;
                            ViewBag.list = listCrops;
                            return View();
                        }
                        break;
                    default:
                        break;
                }
            }
            return Redirect("/Login");
        }

        public async Task<IActionResult> GetProcessList(string processType)
        {

            switch (processType)
            {
                case "care":
                    return PartialView("_CareProcessList", listCare);
                case "harvest":
                    return PartialView("_HarvestProcessList", listHarvest);
                case "plant":
                    return PartialView("_PlantProcessList", listPlant);
                default:
                    return BadRequest("Invalid process type.");
            }
        }


    }
}
