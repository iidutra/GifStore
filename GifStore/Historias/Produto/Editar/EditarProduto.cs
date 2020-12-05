using GifStore.Data;
using Historias.Compartilhado;
using System.Linq;
using System.Threading.Tasks;

namespace GifStore.Historias.Produto.Editar
{
    public class EditarProduto
    {
        private readonly DataContexto contexto;

        public EditarProduto(DataContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Resultado> Executar(EditarProdutoViewModel editarProdutoVm)
        {
            if (editarProdutoVm.Id == 0)
                return Resultado.Erros(new string[] { "Produto não existente!" });

            var produto = contexto.Produtos.First(x => x.Id == editarProdutoVm.Id);
            produto.AlterarDados(
                editarProdutoVm.Nome,
                editarProdutoVm.Status);

            contexto.Update(produto);
            await contexto.SaveChangesAsync();
            return Resultado.Sucesso();
            
        }
    }
}
