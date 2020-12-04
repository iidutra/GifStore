using GifStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifStore.Historias.Cliente.Excluir
{
    public class ExcluirCliente
    {
        private readonly DataContexto contexto;

        public ExcluirCliente(DataContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task Executar(int clienteId)
        {
            var removerCliente = await contexto.Clientes.FirstAsync(x => x.Id == clienteId);

            contexto.Remove(removerCliente);
            await contexto.SaveChangesAsync();
        }
    }
}
