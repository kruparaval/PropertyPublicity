using System.Threading.Tasks;
using OMTechStation.PropertyPublicity.Models.TokenAuth;
using OMTechStation.PropertyPublicity.Web.Controllers;
using Shouldly;
using Xunit;

namespace OMTechStation.PropertyPublicity.Web.Tests.Controllers
{
    public class HomeController_Tests: PropertyPublicityWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}