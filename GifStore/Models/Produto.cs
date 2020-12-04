using GifStore.Data.Enum;

namespace GifStore.Models
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public StatusDaCompra Status { get; set; }
        public Cliente Cliente { get; private set; }
    }
}
