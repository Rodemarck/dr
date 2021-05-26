using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace codigo.ui.botao
{
    [DisallowMultipleComponent]
    public class BotaoMenu : MonoBehaviour
    {
        private static BotaoMenu _btn;
        private void Awake()
        {
            _btn = this;
        }

        public static BotaoMenu Instancia
        {
            get => _btn;
        }

        #region MenuPrincipal
        
        public void NovoJogo()
        {
            SceneManager.LoadScene("cena/game/level2");
        }

        public void Despausar()
        {
            Mundo.Instancia.Pausar = false;
        }
        
        public void Tutorial()
        {
            SceneManager.LoadScene("cena/game/level0");
        }

        public void Sair()
        {
            Debug.Log("kitando aqui!!");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("cena/menu/login");
        }

        public void Menu()
        {
            Debug.Log("menu");
            SceneManager.LoadScene("cena/menu/main_menu");
        }

        #endregion
        
        #region MenuMono

        public void MonoMapa()
        {
            Debug.Log("MonoMapa");
        }

        public void MonoBalas()
        {
            Debug.Log("MonoBalas");
        }

        public void MonoPresentes()
        {
            Debug.Log("MonoPresentes");
        }

        public void MonoRegras()
        {
            Debug.Log("MonoRegras");
        }

        public void MonoConfiguracoes()
        {
            Debug.Log("MonoConfiguracoes");
        }

        #endregion
    }
}