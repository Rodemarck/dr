using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Sprite = codigo.ui.Sprite;

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

        private Dictionary<string, Sprite> tabela;
        public static void get(string nome, out Sprite arg)
        {
            Instancia.tabela.TryGetValue(nome,out arg);
        }
        
        #endregion
        #region Construtor

        public RepositorioPersonagens()
        {
            tabela = new Dictionary<string,Sprite>();
            
        }

        #endregion
    }
}