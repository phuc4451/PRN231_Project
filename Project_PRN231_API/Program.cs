using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Project_PRN231_API.AutoMapper;
using Project_PRN231_API.Models;
using System.Text.Json.Serialization;
namespace WebAPI
{
    public class Program
    {
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<User>("User").EntityType.HasKey(m => m.UserId).Expand(5);
            builder.EntitySet<Crop>("Crop").EntityType.HasKey(s => s.CropId).Expand(5);
            return builder.GetEdmModel();
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("CORSPolicy", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true));
            });

            builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

			builder.Services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100)
            .AddRouteComponents("odata", GetEdmModel()));

            builder.Services.AddAutoMapper(typeof(ApplicationMapper));

            builder.Services.AddDbContext<FarmManagement2_PRN231Context>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASPNETAPI_OData", Version = "v1" });
            });


            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("CORSPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.UseODataBatching();
            app.UseRouting();



            app.Run();
        }
    }
}