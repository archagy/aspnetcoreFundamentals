using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
namespace OdeToFood.Data {
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetByID(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData() {
            restaurants = new List<Restaurant>() {
                new Restaurant { ID = 1, Name = "Taco Roll", Location = "Mexico", Cuisine = CuisineType.Mexican },
                new Restaurant { ID = 2, Name = "Sushi Roll", Location = "Mexico", Cuisine = CuisineType.Indian},
                new Restaurant { ID = 3, Name = "Torta Roll", Location = "Mexico", Cuisine = CuisineType.Italian}
            };
        }


        public Restaurant GetByID(int id) {
            return restaurants.SingleOrDefault(r => r.ID == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
