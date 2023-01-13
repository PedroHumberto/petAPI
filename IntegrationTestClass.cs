using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using petrgAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using petrgAPI.Services;
using System.Net.Http.Headers;
using petrgAPI.Data.Dto.AddressDto;


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
                            opts.UseLazyLoadingProxies().UseSqlServer("server=DESKTOP-EIV2BKE;database=TestDB;Trust Server Certificate=true;User ID=sa;Password=sa12345678");
                        });
                    });
                });
            _testClient = appFactory.CreateClient();
            

        }

        protected async Task<AddressService> AddAddressAsync(CreateAddressDto request){
            
            var response = await _testClient.PostAsJsonAsync("http://localhost:5024/Address", request);


            //retorna Address service já realizando um post
            return await response.Content.ReadAsAsync<AddressService>();
        }

    
        /* //CREATE AN AUTHENTITCATE METOD
        protected async Task AuthentitcateAsync()
        {
            _testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", GetJwdAsync());
        }

        private async Task<string> GetJwdAsync()
        {
            var response = _testClient.PostAsJsonAsync("http://localhost:6000/SingUp", new CreateUserDto(){
                Email = "test@email.com",
                Password = "Senha1234!"
            });

            var registrationResponse = await response. Content.ReadAsAsync<AuthSuccessResponse>();
            return registrationResponse.Token;
        }*/
    }
}