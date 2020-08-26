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
            string nomeMaquina = Environment.MachineName;
            string data = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            var caminhoArquivo = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Log\\Log.txt";

            if (!File.Exists(caminhoArquivo))
                File.Create(caminhoArquivo).Close();
                      
            File.AppendAllText(caminhoArquivo, $"[{nomeMaquina}] {acao} um {detalhes} no modulo {modulo} em {data} \r\n" );

        }
    }
}
