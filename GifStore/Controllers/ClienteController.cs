using GifStore.Data;
using GifStore.Historias.Cliente.Cadastrar;
using GifStore.Historias.Usuario.Cadastrar;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GifStore.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly DataContexto contexto;

        public ClienteController(DataContexto contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            return View(contexto.Clientes.ToList());
        }
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(
            [FromServices] CadastrarCliente cadastrarCliente,
            CadastrarClienteViewModel cadastrarClienteVm)
        {
            if (!ModelState.IsValid)
            {
                return View(cadastrarClienteVm);
            }
            await cadastrarCliente.Executar(cadastrarClienteVm);
            return RedirectToAction(nameof(Index));
        }
    }
}
