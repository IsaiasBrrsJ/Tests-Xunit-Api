using AutoBogus;
using Bogus.Extensions.Extras;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WebApiAndTestsxUnit;
using WebApiAndTestsxUnit.Domain.Model.User;
using Xunit.Abstractions;

namespace TestAPI.Integrations.Controller.Auth
{
    public  class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        protected readonly HttpClient _httpClient;
 

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
        
        }

      
        [Fact]
        public async Task DeveEnviar_O_User_E_Senha_E_RetornarSucesso_E_O_Token() 
        {
            //Arrange
            var user  =(User) new AutoFaker<User>()
                .RuleFor(e => e.Id, fakes => fakes.Database.Random.Int(0, 999))
                .RuleFor(e => e.UserName, fakes => fakes.Person.FirstName)
                .RuleFor(e => e.Password, fakes => fakes.Random.String2(6, 10));

    

            var content = new MultipartFormDataContent
            {
                { new StringContent(user.Id.ToString()), "Id" },
                { new StringContent(user.UserName), "UserName" },
                { new StringContent(user.Password), "Password" }
            };

            //Act
            var response = await  _httpClient.PostAsync("/Login/Auth/Login", content);

            var userKey =  JsonConvert.DeserializeObject<User>( await response.Content.ReadAsStringAsync());

            //Assert
             //Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(userKey);
            //_outputHelper.WriteLine(userKey.ToString());
        }
    }
}