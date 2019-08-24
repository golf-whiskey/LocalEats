using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalEats.Core;
using LocalEats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LocalEats.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetAll();
        }
    }
}