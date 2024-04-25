using Microsoft.AspNetCore.Mvc;
using Models.VETE;
using Services.VETA;


namespace XperTek_ACME.Controllers
{
    public class Veterinaria : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            VETAservice Vservice = new VETAservice();
            List<Dueños>? listaDueños;
            listaDueños = Vservice.Listar();
            return View(listaDueños);
        }
    }
}
