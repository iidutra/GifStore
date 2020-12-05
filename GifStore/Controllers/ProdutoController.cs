using GifStore.Data;
using GifStore.Historias.Produto.Cadastrar;
using GifStore.Historias.Produto.Editar;
using GifStore.Historias.Produto.Excluir;
using GifStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GifStore.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly DataContexto contexto;

        public ProdutoController(DataContexto contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            return View(contexto.Produtos.ToList());
        }
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(
            [FromServices] CadastrarProduto cadastrarProduto,
            CadastrarProdutoViewModel cadastrarProdutoVm)
        {
            if (!ModelState.IsValid)
                return View(cadastrarProdutoVm);

            await cadastrarProduto.Executar(cadastrarProdutoVm);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = contexto.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        public IActionResult Editar(int id)
        {
            var produto = contexto.Produtos.Find(id);
            var resultado = EditarVm(produto);
            return View(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar([FromServices] EditarProduto editarProduto,
            EditarProdutoViewModel editarProdutoVm)
        {
            if (!ModelState.IsValid)
                return View(editarProdutoVm);

            await editarProduto.Executar(editarProdutoVm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Excluir([FromServices] ExcluirProduto excluirProduto, int produtoId)
        {
            var clienteExists = contexto.Clientes.Any(x => x.ProdutoId == produtoId);

            if (clienteExists)
                return BadRequest();

            await excluirProduto.Executar(produtoId);
            NotificarSucesso();
            return RedirectToAction(nameof(Index));
        }

        public EditarProdutoViewModel EditarVm(Produto produto)
        {
            return new EditarProdutoViewModel()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Status = produto.Status
            };
        }
    }
}
