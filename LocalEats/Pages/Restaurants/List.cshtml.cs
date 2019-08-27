using LocalEats.Core;
using LocalEats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LocalEats.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public ListModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}