using LocalEats.Core;
using LocalEats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _HtmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
            {
                Restaurant = _RestaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant()
                {
                };
            }

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _HtmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
            }

            if (Restaurant.Id > 0)
            {
                _RestaurantData.Update(Restaurant);
                TempData["Message"] = "Restaurant updated!";
            }
            else
            {
                _RestaurantData.Add(Restaurant);
                TempData["Message"] = "Restaurant added!";
            }

            _RestaurantData.Commit();

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}