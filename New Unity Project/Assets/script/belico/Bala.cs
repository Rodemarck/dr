using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Solucao.script.interavel.atiravel;
namespace Solucao.script.belico
{
    public abstract class Bala : MonoBehaviour
    {
        public float dano;
        public float tempo;
        private float tempoDecorrido;
        private float potencia;
        private float estrago;
        
        void Start()
        {
            tempoDecorrido = 0f;
        }
        void Update()
        {
            UpdateBala();
        }
        public void UpdateBala()
        {
            tempoDecorrido += Time.deltaTime;
            if (tempoDecorrido > tempo)
                Destroy(gameObject);
        }
        public float Potencia
        {
            get { return potencia; }
            set
            {
                potencia = value;
                estrago = dano * potencia;
            }
        }
        public float Estrago
        {
            get;
        }


        private void OnCollisionEnter(Collision collision)
        {
            AoColidir(collision);
        }

        public abstract void AoColidir(Collision collision);
    }

}