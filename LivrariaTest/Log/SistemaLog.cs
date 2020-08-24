using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.Log
{
    public class SistemaLog
    {
        public void criarLog(string modulo, string acao, string detalhes)
        {
            string caminhoArquivo = @"C:\Log-registro";
            string nomeMaquina = Environment.MachineName;
            string data = DateTime.Now.ToString("yyyy-MM-dd");

            if (!File.Exists(caminhoArquivo))
                File.Create(caminhoArquivo).Close();

            //File.AppendAllText(caminhoArquivo, "[" + nomeMaquina + "]" + acao + "um" + detalhes + "no modulo" + modulo + "em" + DateTime.Now.ToShortDateString + "\r\n");
            File.AppendAllText(caminhoArquivo, $"[{nomeMaquina}] {acao} um {detalhes} no modulo {modulo} em {data} \r\n" );

        }
    }
}
