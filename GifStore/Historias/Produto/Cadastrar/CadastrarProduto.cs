using GifStore.Data;
using System.Threading.Tasks;

namespace GifStore.Historias.Produto.Cadastrar
{
    public class CadastrarProduto
    {
        private readonly DataContexto contexto;

        public CadastrarProduto(DataContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task Executar(CadastrarProdutoViewModel cadastrarProdutoVm)
        {
            var produto = new Models.Produto(
                0,
                cadastrarProdutoVm.Nome,
                cadastrarProdutoVm.Status
                );
            await contexto.AddAsync(produto);
            await contexto.SaveChangesAsync();
        }
    }
}
