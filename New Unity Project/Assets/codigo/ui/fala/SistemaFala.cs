using System;
using System.Collections;
using System.Collections.Generic;
using codigo;
using UnityEngine;
using UnityEngine.UI;

namespace codigo.ui.fala
{
    [System.Serializable]
    [DisallowMultipleComponent]
    public class SistemaFala : MonoBehaviour
    {
        #region singleton
        private static SistemaFala instancia;
        private void Awake()
        {
            if (instancia == null)
                instancia = this;
        }
        public static SistemaFala Instancia
        {
            get { return instancia; }
        }
        #endregion
        #region campos

        private Coroutine acao = null;
        private bool esperandoEntrada = false;
        private int n1=0;
        private int n2=0;
        #endregion

        #region construtor

        private void Start()
        {
            Debug.Log("init");
            estaVisival = false;
        }

        #endregion
        public bool esperando
        {
            get => esperandoEntrada;
        }    
        public bool estaVisival
        {
            get => Mundo.Instancia.camadaFala.active; 
            set => Mundo.Instancia.camadaFala.SetActive(value); 
        }
        public bool estaFalando { get => acao != null; }
       
        public void Fale(Fala fala)
        {
            pareDeFalar();
            acao = StartCoroutine(Falando(fala));
        }
        

        public void pareDeFalar()
        {
            if (estaFalando)
                StopCoroutine(acao);
            acao = null;

        }
        public void Pular()
        {
            esperandoEntrada = true;
        }
        IEnumerator Falando(Fala fala)
        {
            Mundo.Instancia.camadaFala.SetActive(true);
            Mundo.Instancia.nome.text = fala.nome;
            Mundo.Instancia.texto.text = "";
            n1 = 0;
            n2 = fala.texto.Length;
            esperandoEntrada = false;
            while (n1 != n2)
            {
                Mundo.Instancia.texto.text += fala.texto[n1++];
                if (esperandoEntrada)
                {
                    Mundo.Instancia.texto.text = fala.texto;
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            esperandoEntrada = true;
            while (esperandoEntrada)
                yield return new WaitForEndOfFrame();
            pareDeFalar();
        }
    }

}