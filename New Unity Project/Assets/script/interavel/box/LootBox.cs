using UnityEngine;

namespace Solucao.script.interavel.box
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class LootBox : MonoBehaviour,Acionavel
    {
        public string efeito;
        public abstract void AoAcionar();
        public  void MudaAlvo(GameObject go){}
        
    }
}