using GifStore.Data;
using GifStore.Historias.Cliente.Cadastrar;
using System.Threading.Tasks;

namespace GifStore.Historias.Usuario.Cadastrar
{
    public class CadastrarCliente
    {
        private readonly DataContexto contexto;

        public CadastrarCliente(DataContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task Executar(CadastrarClienteViewModel cadastrarCliente)
        {
            var cliente = new Models.Cliente(
                0,
                cadastrarCliente.Nome,
                cadastrarCliente.Email,
                cadastrarCliente.Cpf
                );
            await contexto.AddAsync(cliente);
            await contexto.SaveChangesAsync();
        }
    }
}
