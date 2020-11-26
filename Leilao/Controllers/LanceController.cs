using Leilao.DAO;
using System.Web.Mvc;

namespace Leilao.Controllers
{
    public class LanceController : Controller
    {

        public ActionResult Index()
        {
            return View(LeilaoRepository.GetAll());
        }
    }
}
