jQuery(function ($) {
    //Validação do CPF
    $.validator.addMethod("cpf", function (value, element) {
        value = $.trim(value);
        value = value.replace('.', '');
        value = value.replace('.', '');
        value = value.replace('-', '');

        const cpf = value;

        if (cpf === '') return false;

        if (cpf.length !== 11 ||
            cpf === "00000000000" ||
            cpf === "11111111111" ||
            cpf === "22222222222" ||
            cpf === "33333333333" ||
            cpf === "44444444444" ||
            cpf === "55555555555" ||
            cpf === "66666666666" ||
            cpf === "77777777777" ||
            cpf === "88888888888" ||
            cpf === "99999999999")
            return false;

        var retorno = true

        let add = 0;
        for (let i = 0; i < 9; i++)
            add += parseInt(cpf.charAt(i)) * (10 - i);
        let rev = 11 - (add % 11);
        if (rev === 10 || rev === 11)
            rev = 0;
        if (rev !== parseInt(cpf.charAt(9)))
            retorno = false;
        //Valida 2º digito
        add = 0;
        for (let i = 0; i < 10; i++)
            add += parseInt(cpf.charAt(i)) * (11 - i);
        rev = 11 - (add % 11);
        if (rev === 10 || rev === 11)
            rev = 0;
        if (rev !== parseInt(cpf.charAt(10)))
            retorno = false;

        return this.optional(element) || retorno;
    }, "Informe um CPF válido.");
})