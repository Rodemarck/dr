using Solucao.script.belico;
using Solucao.script.interavel.mecanico;
using UnityEditor;
using UnityEngine;
using Solucao.script.ui;
namespace Solucao.script.interavel.atiravel
{
    [System.Serializable]
    public class Alvo : MonoBehaviour,Atiravel
    {
        public GeraAlvo gerador;
        public void AoDisparo(Bala bala)
        {
            gerador.Conta();
            Destroy(this);
        }
    }
}