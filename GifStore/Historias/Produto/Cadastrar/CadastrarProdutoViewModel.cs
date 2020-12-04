using GifStore.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace GifStore.Historias.Produto.Cadastrar
{
    public class CadastrarProdutoViewModel
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Status do produto")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public StatusDoProduto Status { get; set; }

        
    }
}
