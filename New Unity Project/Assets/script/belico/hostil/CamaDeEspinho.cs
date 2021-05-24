using System;
using System.Collections.Generic;
using Solucao.script.interavel.atiravel.tangivel;
using UnityEngine;

namespace Solucao.script.belico.hostil
{
    [Serializable]
    [DisallowMultipleComponent]
    public class CamaDeEspinho : MonoBehaviour
    {
        [Range(min:0.5f,10f)]
        public float delayDano = 0.5f;

        private Espeto[] _espetos;
        private float sec = 0f;
        private bool afiado = true;

        private void Start()
        {
            var zz = GetComponent<Zumbi>();
            SetDano(zz.dano);
            _espetos = gameObject.GetComponents<Espeto>();
        }

        public void SetDano(float daninho)
        {
            foreach (var espeto in gameObject.GetComponents<Espeto>())
            {
                espeto.danoBase = daninho;
            }
        }


        private void Update()
        {
            if(afiado) return;
            
            sec += Time.deltaTime;
            if (sec >= delayDano)
            {
                Habilita(true);
            }
                
        }

        private void Habilita(bool habilitado)
        {
            afiado = habilitado;
            foreach (var e in _espetos)
            {
                e.collider.enabled = habilitado;
            }
        }

        public bool Fura
        {
            get
            {
                Habilita(false);
                sec = 0f;
                return true;
            }
        }
        
    }
}