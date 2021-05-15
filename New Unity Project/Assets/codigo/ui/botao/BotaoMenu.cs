using UnityEngine;
using UnityEngine.SceneManagement;

namespace codigo.ui.botao
{
    public class BotaoMenu : MonoBehaviour
    {
        #region MenuPrincipal
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