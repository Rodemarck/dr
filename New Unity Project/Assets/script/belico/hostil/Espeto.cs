using System;
using codigo.dados;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Solucao.script.belico.hostil
{
    [System.Serializable]
    public class Espeto : MonoBehaviour,Danoso
    {
        public float danoBase;
        [Range(min: 0.01f, max: 1f)]
        public float flutacao;
        public CamaDeEspinho cama;
        public BoxCollider collider;
        private float aux;

        private void Awake()
        {
            collider = GetComponent<BoxCollider>();
        }

        public float Flutacao
        {
            
            get => 1f - (flutacao/2) + (Random.Range(0f, flutacao) );
        }

        public float CalculaDano()
        {
            if(cama.Fura)
                return Flutacao * danoBase;
            return 0f;
        }
    }
}