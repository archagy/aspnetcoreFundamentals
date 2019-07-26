using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace aspnetcoreFundamentals.Pages.Restaurants {

    

    public class DetailsModel : PageModel {
        public Restaurant Restaurant { get; set; }

        private readonly IRestaurantData restaurantData;

        public DetailsModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id) {
            Restaurant = restaurantData.GetByID(id);
            if(Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
