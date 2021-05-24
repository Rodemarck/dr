using System.Collections;
using System.Collections.Generic;
using System;
using codigo.ui;
using UnityEngine;

using Solucao.script.belico;
using Solucao.script.belico.hostil;
using Solucao.script.interavel;
using Solucao.script.interavel.atiravel.tangivel;
using Solucao.script.interavel.box;
using Solucao.script.interavel.mecanico;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Solucao.script
{
    [Serializable]
    public class Player : Ser
    {
        // Start is called before the first frame update
        private Animator animator;
        public GameObject arma;
        private Arma arma_;
        private CharacterController controller;
        public float velocidade = 2f;
        private float x, y,mx,my;
        public Slider slider;
        void Start()
        {
            slider.minValue = 0f;
            slider.maxValue = vidaMax;
            slider.value = Vida;
            Nasce();
            BarraDeVida();
            animator = GetComponent<Animator>();
            Cursor.visible = false;
            if (arma != null)
                arma_ = arma.GetComponent<Arma>();
        }

        void BarraDeVida()
        {
            slider.value = Vida;
        }

        // Update is called once per frame
        void Update()
        {
            if (!vivo)
            {
                Cursor.visible = true;
                Mundo.Instancia.Salva();
                SceneManager.LoadScene("cena/menu/game_over");
            }
                
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            mx += Input.GetAxis("Mouse X");
            my += Input.GetAxis("Mouse Y");
            if (my > 5)
                my = 5;
            if (my < -8)
                my = -8;
            //Debug.Log(new Vector3(my * -10, mx * 10, 0));
            //
            transform.eulerAngles = new Vector3(my * -10, mx * 10, 0);
            if (arma_ != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("atirando", true);
                    ForceUp("atirando");
                    arma_.Atirar();
                    return;
                }
                else if(Input.GetKeyUp(KeyCode.Space))
                {
                    animator.SetBool("atirando", false);
                    arma_.Cessar();
                }
                if (arma_.estaAtirando)
                {
                    return;
                }
                Andar();
            }
            else
            {
                Andar();
            }
        }
        void ForceUp(string ani)
        {
            animator.enabled = false;
            animator.enabled = true;
            animator.Play(ani);
        }
        void Andar()
        {
            if (x == 0 && y == 0)
            {
                animator.SetBool("correndo", false);
                ForceUp("parado");
            }
            else
            {
                animator.SetBool("correndo", true);
                ForceUp("correndo");
                //transform.Rotate(0, x * velocidadeAngular * Time.deltaTime, 0);
                transform.Translate(x * velocidade * Time.deltaTime, 0, y * velocidade * Time.deltaTime);
                Proximidade();
            }
        }

        void Proximidade()
        {
            try
            {
                var distanciadores = GameObject.FindGameObjectsWithTag("distancia");
                foreach (var distanciador in distanciadores)
                {
                    if (distanciador.gameObject == null) return;
                    var acionador = distanciador.GetComponent<Censor>();
                    if (acionador != null)
                    {
                        if (Vector3.Distance(this.transform.position, distanciador.transform.position) < acionador.distancia)
                        {
                            acionador.AoAcionar();
                        }
                    }
                }
            }catch(Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            var go = other.gameObject;
            switch (go.tag)
            {
                case "pata":
                {
                    var espeto = go.GetComponent<Espeto>();
                    var d = espeto.CalculaDano();
               
                    Vida = -d;
                    Debug.Log("daninho de " + d + ", vida atual = "+Vida);
                    BarraDeVida();
                    break;
                }
                case "box":
                {
                    var box = go.GetComponent<LootBox>();
                    box.AoAcionar();
                    Debug.Log("acionando  box para =" + box.efeito);
                    break;
                }
            }
        }
    }

}