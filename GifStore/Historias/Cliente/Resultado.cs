using System.Collections.Generic;

namespace Historias.Cliente
{
    public abstract class Resultado
    {
        public bool Ok { get; private set; }
        public List<string> Notificacoes { get; set; } = new List<string>();

        public void Sucesso()
        {
            this.Ok = true;
        }

        public void Notificar(string mensagem)
        {
            Ok = false;
            Notificacoes.Add(mensagem);
        }
    }
}