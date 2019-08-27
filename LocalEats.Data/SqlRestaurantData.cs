using LocalEats.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocalEats.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly LocalEatsDbContext _db;

        public SqlRestaurantData(LocalEatsDbContext db)
        {
            _db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _db.Restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if (restaurant != null)
                _db.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in _db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }

        public int GetCountOfRestaurants()
        {
            return _db.Restaurants.Count();
        }
    }
}