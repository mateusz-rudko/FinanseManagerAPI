using Microsoft.AspNetCore.Mvc;

namespace FinanseManagerAPI.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
