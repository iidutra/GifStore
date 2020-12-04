using System.Collections.Generic;
using System.Linq;

namespace Historias.Compartilhado
{
    public class Resultado
    {
        public Resultado(bool sucesso, IEnumerable<string> erros)
        {
            Sucedido = sucesso;
            this.erros = erros.ToArray();
        }

        public bool Sucedido { get; set; }

        public string[] erros { get; set; }

        public static Resultado Sucesso()
        {
            return new Resultado(true, new string[] { });
        }

        public static Resultado Erros(IEnumerable<string> erros)
        {
            return new Resultado(false, erros);
        }
    }
}