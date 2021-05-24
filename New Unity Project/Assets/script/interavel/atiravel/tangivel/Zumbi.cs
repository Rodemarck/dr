using System;
using codigo.ui;
using Solucao.script.belico.hostil;
using Solucao.script.ia;
using Solucao.script.interavel.mecanico;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

namespace Solucao.script.interavel.atiravel.tangivel
{
    [System.Serializable]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CamaDeEspinho))]
    public class Zumbi : Perseguidor
    {
        private Animator animador;
        [Range(min:2,max:5)]
        public float timer=2;
        [Range(1,30)]
        public float velocidade = 1;

        public float Velocidade
        {
            get => velocidade;
            set
            {
                velocidade = value;
                GetComponent<NavMeshAgent>().speed = value;
                GetComponent<Animator>().SetFloat("velocidade",value);
            }
        }
        
        [Range(5,100)]
        public float dano;

        private CamaDeEspinho _camaDeEspinho;
        
        public float Dano
        {
            get => dano;
            set
            {
                dano = value;
                GetComponent<CamaDeEspinho>().SetDano(dano);
            }
        }
        public float sec = 0f;
        public GeraAlvo geraAlvo;
        private void Start()
        {
            VelhoStart();
            animador = GetComponent<Animator>();
            _camaDeEspinho = GetComponent<CamaDeEspinho>();
            Velocidade = velocidade;
            
            Nasce();
        }   

        private void Update()
        {
            if (!vivo)
            {
                
                sec += Time.deltaTime;
                if(sec > timer)
                    Destroy(gameObject);
                return;
            }
            VelhoUpdate();
            if (Distancia <= 1.5f){
                animador.SetBool("atacando", true);
                animador.SetBool("andando", false);
                animador.SetBool("parado", false);
            }else{
                animador.SetBool("atacando", false);
                animador.SetBool("andando", true);
                animador.SetBool("parado", false); 
            }
            if(Distancia < distanciaMinima){
                parar = true;
                animador.SetBool("atacando", true);
                animador.SetBool("andando", true);
                animador.SetBool("parado", true);
            }
            else{
                parar = false;
                
            }

            if (Distancia >= distanciaMax)
            {
                animador.SetBool("atacando", false);
                animador.SetBool("andando", false);
                animador.SetBool("parado", true);
            }

        }

        public void LevaDano(float dano)
        {

            if (vivo)
            {
                Vida = dano;
                Mundo.Instancia.InimigoDano(Vida,vidaMax);
                if(!vivo){
                    Gerenciador.Instancia.Kill();
                    animador.enabled = false;
                    animador.enabled = true;
                    animador.SetBool("morto",true);
                    animador.Play("morre");
                    geraAlvo.Conta();
                }
                Debug.Log("dano de " + dano + ", vida =" + Vida);
            }
            else
            {
                Debug.Log("atirando em cadaver");
            }
        }
    }
}