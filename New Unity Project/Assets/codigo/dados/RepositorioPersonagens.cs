using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace codigo.dados
{
    public class RepositorioPersonagens
    {
        #region Singleton

        private static RepositorioPersonagens instancia;

        public static RepositorioPersonagens Instancia
        {
            get { return instancia ?? (instancia = new RepositorioPersonagens()); }
        }

        #endregion
        #region Campos

        private Dictionary<string, string> tabela;
        
        public static void caminho(string nome, out string arg)
        {
            Instancia.tabela.TryGetValue(nome,out arg);
        }

        #endregion
        #region Construtor

        public RepositorioPersonagens()
        {
            tabela = new Dictionary<string,string>();
            tabela.Add("","");
        }

        #endregion
    }
}