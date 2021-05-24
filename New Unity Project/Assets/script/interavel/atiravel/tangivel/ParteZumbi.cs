using codigo.ui;
using Solucao.script.belico;
using UnityEngine;

namespace Solucao.script.interavel.atiravel.tangivel
{
    [System.Serializable]
    public class ParteZumbi :MonoBehaviour, Atiravel
    {
        public Zumbi zumbi;
        [Range(min:0.5f,max:10)]
        public float multiplicador;

        public bool cabeca = false;
        public void AoDisparo(Bala bala)
        {
            Mundo.Instancia.DisparoAcerto();
            if (cabeca)
                Mundo.Instancia.DisparoHS();
            zumbi.LevaDano(bala.dano * multiplicador * -1);
        }
        
    }
}