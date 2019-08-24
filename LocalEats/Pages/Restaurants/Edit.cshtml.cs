using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalEats.Core;
using LocalEats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocalEats.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _RestaurantData;
        private readonly IHtmlHelper _HtmlHelper;

        public EditModel(IRestaurantData _restaurantData, 
                         IHtmlHelper _htmlHelper)
        {
            _RestaurantData = _restaurantData;
            _HtmlHelper = _htmlHelper;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = _HtmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = _RestaurantData.GetById(restaurantId);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            _RestaurantData.Update(Restaurant);
            _RestaurantData.Commit();

            return Page();
        }
    }
}