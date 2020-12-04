using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GifStore.Historias.Cliente.Editar
{
    public class EditarClienteViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Email { get; set; }
    }
}
