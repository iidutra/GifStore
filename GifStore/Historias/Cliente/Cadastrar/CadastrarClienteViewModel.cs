using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GifStore.Historias.Cliente.Cadastrar
{
    public class CadastrarClienteViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public int ProdutoId { get; set; }
    }
}
