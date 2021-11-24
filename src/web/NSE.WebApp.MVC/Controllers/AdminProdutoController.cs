using Microsoft.AspNetCore.Mvc;

namespace NSE.WebApp.MVC.Controllers
{
    public class AdminProdutoController : Controller
    {
        [Route("admin-produto")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
