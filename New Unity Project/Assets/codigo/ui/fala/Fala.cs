using System;
using System.Collections.Generic;
using System.IO;

namespace codigo.ui.fala
{
    [Serializable]
    public class Fala
    {
        public string nome;
        public string texto;
        public Sprite[] sprites;
        

        public Fala(string nome, string texto)
        {
            this.nome = nome;
            this.texto = texto;
        }

        public Fala(IReadOnlyList<string> args)
        {
            nome = args[0];
            texto = args[1];
            if (args.Count != 3) return;
            
            var partes = args[2].Split(new [] {";;"}, StringSplitOptions.None);
            sprites = new Sprite[partes.Length];
            for (var i = 0; i < sprites.Length; i++)
                sprites[i] = Sprite.Cria(partes[i]);
        }
        public static Fala[] ApartirDeArquivo(string caminho) 
        {
            try
            {
                using (var leitor = new StreamReader("Assets/recursos/falas/" + caminho + ".txt"))
                {
                    var texto = leitor.ReadToEnd();
                    var falasBrutas = texto.Split( '\n');
                    var separador = new [] { "::" };
                    var falas = new Fala[falasBrutas.Length];
                    var n = 0;
                    foreach (var falaBruta in falasBrutas)
                    {
                        falas[n++] = new Fala(falaBruta.Split(separador, StringSplitOptions.None));
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
