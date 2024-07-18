using Project_PRN231_Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class CropController : Controller
    {
        private readonly string link = "http://localhost:5000/api/";
        HttpClient _client;

        public CropController()
        {
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index(int CropId)
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                Crop crop = new Crop();
                string odataQuery = CropId + "?$expand=CareProcesses,HarvestProcesses,PlantProcesses";
                HttpResponseMessage response = await _client.GetAsync(link + "Crop/" + odataQuery);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    crop = JsonConvert.DeserializeObject<Crop>(data);
                    //ViewBag.Keyword = keyword;
                    return View(crop);
                }
            }
            return Redirect("/Login");
        }
    }
}
