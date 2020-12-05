using GifStore.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace GifStore.Historias.Produto.Editar
{
    public class EditarProdutoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public StatusDoProduto Status { get; set; }

    }
}
