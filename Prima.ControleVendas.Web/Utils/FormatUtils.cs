using System;

namespace Prima.ControleVendas.Web.Utils
{
    public static class FormatUtils
    {
        public static long ConverterStringParaCPF(string cpf)
        {
            return Convert.ToInt64(cpf.Replace(".", "").Replace("-", ""));
        }
    }
}
