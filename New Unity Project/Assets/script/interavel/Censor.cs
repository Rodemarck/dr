using UnityEditor;
using UnityEngine;

namespace Solucao.script.interavel
{
    public class Censor : MonoBehaviour, AcionavelDistancia
    {
        public bool ativado;
        public bool unico;
        public float distancia;
        public GameObject alvo;
        private Renderer render;

        void Start()
        {
            render = GetComponent<Renderer>();
            render.enabled= ativado;
        }
        public void AoAcionar()
        {
            if (ativado)
            {
                if(alvo != null)
                    alvo.SendMessage("AoAcionar");
                if (unico)
                    Destroy(this.gameObject);
                ativado = false;
            }
            else
            {
                ativado = true;
                render.enabled = ativado;
            }
            
        }

        public float Distancia()
        {
            return distancia;
        }

        public void MudaAlvo(GameObject go)
        {
            alvo = go;
        }
    }
}