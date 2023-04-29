using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
      public List<Products> products = new List<Products>(); 

        public void OnGet()
        {
            DbService odbservice = new DbService();

            products = odbservice.GetProducts();
        }
    }
}