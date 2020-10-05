using Microsoft.EntityFrameworkCore;
using CountingCalories.DataAccess.Repository.Implementation;
using Xunit;

namespace CountingCalories.DataAccess.Tests
{
    public class FoodRepositoryTests
    {

        [Fact]
        public void TestGetAllFood()
        {
            var contextOptions = new DbContextOptions<CountingCaloriesContext>();
            FoodRepository repo = new FoodRepository(new CountingCaloriesContext(contextOptions));
            var res = repo.GetAllFood();
            Assert.NotNull(res);
        }
    }
}
