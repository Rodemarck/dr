using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace codigo.ui.menu
{
    [System.Serializable]
    public class MonoMenu : MonoBehaviour
    {
        #region Singleton

        private static MonoMenu _intancia;

        public static MonoMenu Intancia
        {
            get => _intancia;
        }

        private void Awake()
        {
            if (_intancia == null)
                _intancia = this;
        }
        #endregion

        #region campos

        private bool mostrando;

        private bool _mostrando_personagem;
        private bool _mostrando_menu;
        private bool _mostrando_fala;

        public MonoBotao[] monoBotoes;
        private int index;
        
        #endregion

        #region Construtor

        private void Start()
        {
            mostrando = false;
            monoBotoes = FindObjectsOfType<MonoBotao>();
            var i = 0;
            index = 0;
            Mundo.Instancia.camadaMenu.SetActive(false);
            foreach (var botao in monoBotoes)
            {
                botao.index = i++;
                botao.GetComponent<Button>().onClick.Invoke();
            }

            Ler();
            
        }
        #endregion

        private void Ler()
        {
            _mostrando_fala = Mundo.Instancia.camadaFala.activeInHierarchy;
            _mostrando_menu = Mundo.Instancia.camadaMenu.activeInHierarchy;
            _mostrando_personagem = Mundo.Instancia.camadaPersonagens.activeInHierarchy;
        }

        private void Escrever()
        {
            Mundo.Instancia.camadaFala.SetActive(_mostrando_fala);
            Mundo.Instancia.camadaMenu.SetActive(_mostrando_menu);
            Mundo.Instancia.camadaPersonagens.SetActive(_mostrando_personagem);
        }

        private void Update()
        {
            if (Mundo.Instancia.permiteMenu )
            {
                if (Input.GetKeyDown(KeyCode.F2))
                {
                    if (mostrando)
                        Escrever();
                    else
                    {
                        Ler();
                        Mundo.Instancia.camadaFala.SetActive(false);
                        Mundo.Instancia.camadaMenu.SetActive(true);
                        Mundo.Instancia.camadaPersonagens.SetActive(false);
                    }
                }

                if (Input.GetButtonDown("Submit"))
                {
                    
                }
            }
                   
        }

        private MonoBotao get()
        {
            return monoBotoes.FirstOrDefault(monoBotao => monoBotao.index == index);
        }

        public void PassaMouse(int i)
        {
            index = i;
            foreach (var botao in monoBotoes)
                botao.Levantado = botao.index == i;
        }
    }
}