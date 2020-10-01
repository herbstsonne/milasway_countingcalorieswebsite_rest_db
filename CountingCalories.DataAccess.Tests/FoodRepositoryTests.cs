using CountingCalories.Domain.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CountingCalories.DataAccess.Tests
{
    public class FoodRepositoryTests
    {

        [Fact]
        public void TestGetAllFood()
        {
            var contextOptions = new Mock<DbContextOptions<CountingCaloriesContext>>();
            var context = new Mock<CountingCaloriesContext>();
            var repo = new Mock<IFoodRepository>();
            //repo.Setup()
            //var res = repo.GetAllFood();
            //Assert.NotNull(res);
        }
    }
}
