jQuery(function ($) {
    let formCadastro = $('#formCadastrarCliente');
    if (formCadastro.length) {
        formCadastro.validate({
            errorClass: "text-danger",
            rules: {
                Cpf: {
                    required: true,
                    cpf: true
                },
                Nome: {
                    required: true
                },
                Email: {
                    required: true,
                    email: true
                },
                Contato: {
                    required: true
                }
            },
            messages: {
                Cpf: {
                    required: 'Preencha o campo CPF para continuar',
                    cpf: 'Informe um CPF válido.'
                },
                Nome: {
                    required: 'Preencha o campo Nome para continuar'
                },
                Email: {
                    required: 'Preencha o campo Email para continuar',
                    email: 'Informe um email válido.'
                },
                Contato: {
                    required: 'Preencha o campo Contato para continuar'
                }
            }
        });
    }
})