using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEFMultiplesBBDD.Models;
using MvcNetCoreEFMultiplesBBDD.Repositories;

namespace MvcNetCoreEFMultiplesBBDD.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<EmpleadoView> empleados = await
                this.repo.GetEmpleadosViewAsync();
            return View(empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            EmpleadoView empleado = await
                this.repo.FindEmpleadoViewAsync(id);
            return View(empleado);
        }
    }
}
