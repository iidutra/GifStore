namespace Historias.Compartilhado.Extensoes
{
    public static class StringExtensao
    {
        public static string LimparCpfCnpj(this string cpfCnpj)
        {
            return cpfCnpj.Replace(".", "").Replace("/", "").Replace("-", "");
        }

        public static string LimparContato(this string contato)
        {
            return contato.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
        }

        public static string LimparCep(this string contato)
        {
            return contato.Replace("-", "");
        }
    }
}