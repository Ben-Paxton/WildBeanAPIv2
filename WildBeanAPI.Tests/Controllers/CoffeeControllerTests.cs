using Microsoft.AspNetCore.Mvc;
using WildBeanAPI.Controllers;
using WildBeanAPI.Utils;

namespace WildBeanAPI.Tests.Controllers
{
    public class CoffeeControllerTests
    {
        [Fact]
        public void CoffeeController_BrewCoffee_Return200()
        {
            //Arrange
            var controller = new CoffeeController();

            //Act
            var response = controller.Get();

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.NotNull(objectResponse);
            Assert.Equal(200, objectResponse.StatusCode);
        }

        [Fact]
        public void CoffeeController_BrewCoffee_Return418()
        {
            //Arrange
            var controller = new CoffeeController();

            //Act            
            var response = (IActionResult?)null;
            var fakeDate = new DateTime(2023, 4, 1);
            using (var context = new DateTimeProviderContext(fakeDate))
            {
                response = controller.Get();
            }            

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.NotNull(objectResponse);
            Assert.Equal(418, objectResponse.StatusCode);
        }
    }
}