using System;
using codigo.ui.botao;
using UnityEngine;

namespace codigo.ui.menu
{
    [DisallowMultipleComponent]
    public class MainMenu : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(BotaoMenu.Instancia.form);
            
            BotaoMenu.Instancia.form.SetActive(true);
            BotaoMenu.Instancia.mensagem.SetActive(false);
        }
    }
}