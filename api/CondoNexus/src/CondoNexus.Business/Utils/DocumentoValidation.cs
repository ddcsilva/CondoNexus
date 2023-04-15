namespace CondoNexus.Business.Utils;

public static class DocumentoValidation
{
    public static bool ValidarCpf(string cpf)
    {
        cpf = RemoverFormatacao(cpf);

        if (!PossuiTamanhoValido(cpf, 11) || TemDigitosRepetidos(cpf))
            return false;

        return VerificarDigitosCpf(cpf);
    }

    public static bool ValidarCnpj(string cnpj)
    {
        cnpj = RemoverFormatacao(cnpj);

        if (!PossuiTamanhoValido(cnpj, 14))
            return false;

        return VerificarDigitosCnpj(cnpj);
    }

    private static string RemoverFormatacao(string documento)
    {
        return documento.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
    }

    private static bool PossuiTamanhoValido(string documento, int tamanho)
    {
        return documento.Length == tamanho;
    }

    private static bool TemDigitosRepetidos(string documento)
    {
        for (int i = 0; i < 10; i++)
            if (documento == new string(i.ToString()[0], documento.Length))
                return true;

        return false;
    }

    private static bool VerificarDigitosCpf(string cpf)
    {
        int[] digitosCalculados = CalcularDigitosCpf(cpf);

        return cpf.EndsWith($"{digitosCalculados[0]}{digitosCalculados[1]}");
    }

    private static bool VerificarDigitosCnpj(string cnpj)
    {
        int[] digitosCalculados = CalcularDigitosCnpj(cnpj);

        return cnpj.EndsWith($"{digitosCalculados[0]}{digitosCalculados[1]}");
    }

    private static int[] CalcularDigitosCpf(string cpf)
    {
        int[] digitos = new int[2];

        digitos[0] = CalcularDigitoVerificador(cpf.Substring(0, 9), new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 });
        digitos[1] = CalcularDigitoVerificador(cpf.Substring(0, 10), new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 });

        return digitos;
    }

    private static int[] CalcularDigitosCnpj(string cnpj)
    {
        int[] digitos = new int[2];

        digitos[0] = CalcularDigitoVerificador(cnpj.Substring(0, 12), new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
        digitos[1] = CalcularDigitoVerificador(cnpj.Substring(0, 13), new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

        return digitos;
    }

    private static int CalcularDigitoVerificador(string documento, int[] multiplicadores)
    {
        int soma = 0;

        for (int i = 0; i < documento.Length; i++)
        {
            soma += (documento[i] - '0') * multiplicadores[i];
        }

        int resto = soma % 11;

        return resto < 2 ? 0 : 11 - resto;
    }
}
