using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ArkansasAssetBuilders.Data;
using System.Data;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;

namespace ArkansasAssetBuilders
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<ClientContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("ClientContext")));

        }

        ////Function to Insert Records  
        //private void InsertCSVRecords(DataTable csvdt)
        //{
        //    connection();
        //    //creating object of SqlBulkCopy    
        //    SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //    //assigning Destination table name    
        //    objbulk.DestinationTableName = "Employee";
        //    //Mapping Table column    
        //    objbulk.ColumnMappings.Add("Name", "Name");
        //    objbulk.ColumnMappings.Add("City", "City");
        //    objbulk.ColumnMappings.Add("Address", "Address");
        //    objbulk.ColumnMappings.Add("Designation", "Designation");
        //    //inserting Datatable Records to DataBase    
        //    con.Open();
        //    objbulk.WriteToServer(csvdt);
        //    con.Close();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
