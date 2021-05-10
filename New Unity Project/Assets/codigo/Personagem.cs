using System;
using codigo.ui.fala;
using UnityEngine;

namespace codigo
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class Personagem : MonoBehaviour
    {
        #region Campo 

        private Rigidbody Rigidbody;
        
        [Range(1,5)]
        public float velocidade;
        [Range(0.3f,2)]
        public float tempoRotacao;
        private float aux;
        private float tempo;
        
        private Rigidbody rigidbody;

        #endregion
        #region Construtor

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            tempo = 0f;
        }

        #endregion

        private void Update()
        {
            tempo += Time.deltaTime;
            if(!SistemaFala.Instancia.estaFalando)
                Andar();
        }

        void Andar()
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * velocidade, 0,Input.GetAxis("Vertical") * Time.deltaTime * velocidade);
            aux = Input.GetAxis("Rotacionar");
            if (aux != 0 && tempo > tempoRotacao)
            {
                tempo = 0f;
                transform.Rotate(0,aux * 90,0);
            }
        }
    }
}