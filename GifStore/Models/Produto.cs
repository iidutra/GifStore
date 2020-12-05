using GifStore.Data.Enum;

namespace GifStore.Models
{
    public class Produto
    {

        public Produto(int id, string nome, StatusDoProduto status)
        {
            Id = id;
            Nome = nome;
            Status = status;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public StatusDoProduto Status { get; set; }
        public Cliente Cliente { get; private set; }

        public void AlterarDados(string nome, StatusDoProduto status)
        {
            Nome = nome;
            Status = status;
        }
    }
}
