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

        public GameObject form;
        public GameObject mensagem;
        public Text textoMensagem;

        public void Ok()
        {
            form.SetActive(true);
            mensagem.SetActive(false);
        }
        public void NovoJogo()
        {
            if (Sessao.Instancia.conta.personagens.Count >= 3)
            {
                textoMensagem.text = "O limite de personagens por conta é 3";
                form.SetActive(false);
                mensagem.SetActive(true);
            }
            else
                SceneManager.LoadScene("level_0");
        }

        public void Carregar()
        {
            SceneManager.LoadScene("carregar");
        }

        public void Sair()
        {
            Debug.Log("kitando aqui!!");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("cena/menu/login");
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