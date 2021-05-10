using System;
using System.IO;
using UnityEngine;

namespace codigo.ui.fala
{
    public class Fala
    {
        public string nome;
        public string texto;

        public Fala(string nome, string texto)
        {
            this.nome = nome;
            this.texto = texto;
        }

        public static Fala[] ApartirDeArquivo(string caminho) 
        {
            try
            {
                using (var leitor = new StreamReader("Assets/falas/" + caminho + ".txt"))
                {
                    var texto = leitor.ReadToEnd();
                    var falasBrutas = texto.Split(new char[] { '\n' });
                    var separador = new string[] { "::" };
                    var falas = new Fala[falasBrutas.Length];
                    var n = 0;
                    foreach (var falaBruta in falasBrutas)
                    {
                        var partes = falaBruta.Split(separador, StringSplitOptions.None);
                        falas[n++] = new Fala(partes[0], partes[1]);
                    }
                    return falas;
                }
            }
            catch (IOException e)
            {
                throw e;
            } 
        }
    }
}
