using System;
using codigo.dados;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace codigo.ui
{
    [DisallowMultipleComponent]
    
    public class Sessao : MonoBehaviour
    {
        private static Sessao _sessao;

        public static Sessao Instancia
        {
            get => _sessao;
        }
        #region Player

        public Conta conta;
        public string personagem;
        #endregion
        
        
        private void Awake()
        {
            _sessao = this;
            //SceneManager.GetActiveScene().name
            if (SceneManager.GetActiveScene().name == "login" ||
                SceneManager.GetActiveScene().name == "cadastro") 
                return;
            if (!(PlayerPrefs.HasKey("_id") || PlayerPrefs.HasKey("conta")))
                SceneManager.LoadScene("cena/menu/login");
            if (SceneManager.GetActiveScene().name != "main_menu" && !PlayerPrefs.HasKey("personagem"))
                SceneManager.LoadScene("cena/menu/main_menu");
        }

        private void Start()
        {
            conta = JsonConvert.DeserializeObject<Conta>(PlayerPrefs.GetString("conta"));
            if (PlayerPrefs.HasKey("personagem"))
                personagem = PlayerPrefs.GetString("personagem");
        }
    }
}