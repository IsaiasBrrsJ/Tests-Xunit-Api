using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http.Json;
using TestAPI.Integrations.Controller.Auth;
using WebApiAndTestsxUnit;
using WebApiAndTestsxUnit.Domain.Model.User;
using Xunit.Abstractions;

namespace TestAPI.Integrations.Controller.Users
{
    public class UserControllerTests : AuthControllerTests
    {
        public UserControllerTests(WebApplicationFactory<Program> factory) : base(factory) { }
      
        [Fact]
        public async Task DeveInserirUmUserERetornarSucesso()
        {
            //Arrange
            var user = new User
            {
                Id = 1,
                UserName = "isaias",
                Password = "1234"
            };

            var formPost = new MultipartFormDataContent
           {
               {new StringContent(user.Id.ToString()), "Id"},
               {new StringContent(user.UserName), "UserName"},
               {new StringContent(user.Password), "Password"}
           };

            //Act
            var response =await _httpClient.PostAsync("/Api/User", formPost);    
       
            //Assert
        
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task EnviaIdParaAPIEhDeveRetornarSucesso()
        {
            //Arrange

            int Id = 1;
            //Act

            var response = _httpClient.GetAsync($"/Api/User/{Id}").GetAwaiter().GetResult();
            //Assert

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
      
        }
    }
}
