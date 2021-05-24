using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Solucao.script.ui
{
    [System.Serializable]
    [DisallowMultipleComponent]
    public class GerenciadorMundo : MonoBehaviour
    {
        #region singleton
        void Awake()
        {
            if (_gerenciadorMundo == null)
                _gerenciadorMundo = this;
        }
        #endregion

        private static GerenciadorMundo _gerenciadorMundo;
        private static int censores = 0;
        private static int mortes = 0;
        private static int objetivos = 0;
        public Level level;
        public static GerenciadorMundo Instancia
        {
            get => _gerenciadorMundo;
        }
        public void AcionaCensor()
        {
            ++censores;
        }
        public void RealizaObjetivo()
        {
            if (++objetivos == level.numeroObjetivos)
                SceneManager.LoadScene(level.proximaFase);
        }
        [System.Serializable]
        public class Level 
    {
        public int numeroObjetivos;
        public string proximaFase;
    }

        public void Kill()
        {
            ++mortes;
        }
    }
}