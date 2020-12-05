using GifStore.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GifStore.Historias.Produto.Excluir
{
    
    public class ExcluirProduto
    {
        private readonly DataContexto contexto;

        public ExcluirProduto(DataContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task Executar(int produtoId)
        {
            var removerProduto = await contexto.Produtos.FirstAsync(x => x.Id == produtoId);

            contexto.Remove(removerProduto);
            await contexto.SaveChangesAsync();
        }
    }
}
