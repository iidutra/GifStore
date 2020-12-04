using GifStore.Data;
using GifStore.Historias.Cliente.Cadastrar;
using GifStore.Historias.Cliente.Editar;
using GifStore.Historias.Cliente.Excluir;
using GifStore.Historias.Usuario.Cadastrar;
using GifStore.Models;
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
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = contexto.Clientes.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }
        public async Task<IActionResult> Editar(int id)
        {
            var cliente = contexto.Clientes.Find(id);
            var resultado = EditarVM(cliente);
            return View(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar([FromServices] EditarCliente editarCliente,
            EditarClienteViewModel editarClienteVm)
        {
            if (!ModelState.IsValid)
                return View(editarClienteVm);

            await editarCliente.Executar(editarClienteVm);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> Excluir([FromServices] ExcluirCliente excluirCliente, int clienteId)
        {
            await excluirCliente.Executar(clienteId);
            NotificarSucesso();
            return RedirectToAction(nameof(Index));
        }

        public EditarClienteViewModel EditarVM(Cliente cliente)
        {
            return new EditarClienteViewModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf
            };
        }
    }
}
