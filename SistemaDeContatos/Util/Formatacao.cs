using System;

namespace SistemaDeContatos.Util
{
    public class Formatacao
    {
        public static string FormatarDataHora(DateTime date)
        {
            var formatoBrasileiro = new System.Globalization.CultureInfo("pt-BR");
            Console.WriteLine(date);
            return date.ToString("dd/MM/yyyy HH:mm:ss", formatoBrasileiro);
        }
    }
}
