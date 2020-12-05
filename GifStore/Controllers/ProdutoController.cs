using GifStore.Data;
using GifStore.Historias.Produto.Cadastrar;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GifStore.Controllers
{
    public class ProdutoController : Controller
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
    }
}
