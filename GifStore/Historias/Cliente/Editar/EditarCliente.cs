using GifStore.Data;
using Historias.Compartilhado;
using System.Linq;
using System.Threading.Tasks;

namespace GifStore.Historias.Cliente.Editar
{
    public class EditarCliente
    {
        private readonly DataContexto contexto;

        public EditarCliente(DataContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task<Resultado> Executar(EditarClienteViewModel clienteVm)
        {
            if (clienteVm.Id == 0)
                return Resultado.Erros(new string[] { "Cliente não existente!" });

            var cliente =  contexto.Clientes.First(x => x.Id == clienteVm.Id);
            cliente.AlterarDados(
                clienteVm.Nome,
                clienteVm.Email,
                clienteVm.Cpf);

            contexto.Update(cliente);
            await contexto.SaveChangesAsync();
            return Resultado.Sucesso();
        }
    }
}
