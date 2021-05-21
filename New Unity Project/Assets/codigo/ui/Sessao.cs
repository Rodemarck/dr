using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace codigo.ui
{
    [DisallowMultipleComponent]
    
    public class Sessao : MonoBehaviour
    {
        private static Sessao _sessao;
        
        private void Awake()
        {
            _sessao = this;
            //SceneManager.GetActiveScene().name
            if (SceneManager.GetActiveScene().name == "login" ||
                SceneManager.GetActiveScene().name == "cadastro") 
                return;
            if (!(PlayerPrefs.HasKey("_id") || PlayerPrefs.HasKey("conta")))
                SceneManager.LoadScene("cena/menu/login");

        }
    }
}