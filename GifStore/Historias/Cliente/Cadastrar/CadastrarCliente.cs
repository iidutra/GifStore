using GifStore.Data;
using GifStore.Historias.Cliente.Cadastrar;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GifStore.Historias.Usuario.Cadastrar
{
    public class CadastrarCliente
    {
        private readonly DataContexto contexto;
        public Dictionary<string, string> Erros { get; private set; }


        public CadastrarCliente(DataContexto contexto)
        {
            this.contexto = contexto;
            Erros = new Dictionary<string, string>();
        }
        public async Task Executar(CadastrarClienteViewModel cadastrarCliente)
        {
            var clienteExists = await contexto.Clientes.AnyAsync(x => x.Cpf == cadastrarCliente.Cpf || x.Email == cadastrarCliente.Email);
         
            if (clienteExists)
            {
                Erros.Add("Cliente", "CPF ou Email já cadastrado, por favor insira os dados válidos!");
            }

            var cliente = new Models.Cliente(
                0,
                cadastrarCliente.Nome,
                cadastrarCliente.Email,
                cadastrarCliente.Cpf,
                cadastrarCliente.ProdutoId
                );

            await contexto.AddAsync(cliente);
            await contexto.SaveChangesAsync();
        }
    }
}
