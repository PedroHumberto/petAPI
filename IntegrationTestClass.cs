using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using petrgAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace PetRGTest
{
    public class IntegrationTestClass
    {   
        protected readonly HttpClient _testClient;
        protected IntegrationTestClass()
        {

            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(AppDbContext));
                        services.AddDbContext<AppDbContext>(opts =>
                        {
                            opts.UseInMemoryDatabase("TestDb");
                        });
                    });
                });
            _testClient = appFactory.CreateClient();
            

        }

    
        /* CREATE AN AUTHENTITCATE METOD
        protected async Task AuthentitcateAsync()
        {
            _testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue.Parse("bearer", GetJwdAsync());
        }

        private async Task<string> GetJwdAsync()
        {
            var response = _testClient.PostAsJsonAsync("HTTP:///....., new User(){
                Email = "test@email.com
                Password = "Senha1234!"
            });
        }*/
    }
}