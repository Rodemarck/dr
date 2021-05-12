using UnityEngine;
using UnityEngine.SceneManagement;

namespace codigo.ui.botao
{
    public class BotaoMenu : MonoBehaviour
    {
        public void NovoJogo()
        {
            SceneManager.LoadScene("level_0");
        }

        public void Carregar()
        {
            SceneManager.LoadScene("carregar");
        }

        public void Sair()
        {
            Debug.Log("kitando aqui!!");
            Application.Quit();
        }
    }
}