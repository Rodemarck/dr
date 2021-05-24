using UnityEditor;
using UnityEngine;

namespace Solucao.script.interavel
{
    public class Porta : MonoBehaviour, Acionavel
    {
        public GameObject alvo;
        private Animator animator;
        private bool aberto = false;
        
        void Start()
        {
            animator = GetComponent<Animator>();
            animator.SetBool("aberto", aberto);
        }
        public void AoAcionar()
        {
            aberto = !aberto;
            animator.SetBool("aberto", aberto);
            if (alvo != null)
                alvo.SendMessage("AoAcionar");
        }

        public void MudaAlvo(GameObject go)
        {
            //throw new System.NotImplementedException();
        }
    }
}