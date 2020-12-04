$(document).ready(function () {
    $('.mask-cpf').mask('000.000.000-00');
    $('.mask-contato').mask('(00) 00000-0000');
    $('.mask-cep').mask('00000-000');

    //Mascara CPF e CNPJ
    let txtCpf = $('.mask-cpf-cnpj');
    if (txtCpf.length) {
        var cpfMask = function (val) {
            return val.replace(/\D/g, '').length <= 11 ? '000.000.000-00' : '00.000.000/0000-00';
        };

        let cpfOptions = {
            onKeyPress: function (val, e, field, options) {
                field.mask(cpfMask.apply({}, arguments), options);
            }
        };

        txtCpf.mask(cpfMask, cpfOptions);
    }
});