using System;
using System.Globalization;
using System.Net.Mime;
using codigo.dados;
using codigo.ui.botao;
using codigo.ui.fala;
using codigo.ui.menu;
using Newtonsoft.Json;
using Solucao.script;
using Solucao.script.belico;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace codigo.ui
{
    
    [Serializable]
    [RequireComponent(typeof(Sessao))]
    [RequireComponent(typeof(BotaoMenu))]
    [DisallowMultipleComponent]
    public class Mundo : MonoBehaviour
    {
        #region Singleton

        private static Mundo _intancia;

        public static Mundo Instancia
        {
            get => _intancia;
        }

        private void Awake()
        {
            if (_intancia == null)
                _intancia = this;
        }
        #endregion
        #region Campos

        public Player palyer;
        private Arma _arma;
        
        #region Camadas
        [Header("Camadas")] 
        public GameObject camadaPersonagens;
        [HideInInspector] public bool permitePersonagem = true;
        public GameObject camadaMenu;
        [HideInInspector] public bool permiteMenu = true;
        public GameObject camadaFala;
        [HideInInspector] public bool pemiteFala = true;
        #endregion
        #region Menus
        
        [HideInInspector] public GameObject menuMono;
        [HideInInspector] public GameObject menuMapa;
        [HideInInspector] public GameObject menuBala;
        [HideInInspector] public GameObject menuPresente;
        [HideInInspector] public GameObject menuRegra;
        [HideInInspector] public GameObject menuConfiguracao;
        
        #endregion
        #region Fala
        [Header("Sistema de fala")]
        [Space(20)]
        public Text texto;

        public Text nome;
        public Text descricao;


        private Fala[] falas;
        private Dialogo di;
        private int pos=0;
        #endregion
        #region Cursor
        
        [Header("Cursor do mouse")]
        [Space(20)]
        public Texture2D cursorNormal;

        public Texture2D cursorObjeto;

        public Texture2D mouseGame;

        private Vector2 vobj = new Vector2(15, 15);


        #endregion
        #region Movimentação

        public bool girar = true;
        public bool mover = true;

        #endregion
        #region Labels
        [Header("GamePlay")]
        [Space(20)]
        public Text horda;
        public Text kill;
        public Text precisao;
        public Text hs;
        public Text balas;
        

        #endregion
        #endregion
        #region Construtor

        private void Start()
        {
            MouseNormal();
            falas = new Fala[0];
            if(descricao != null)
                descricao.enabled = false;
            if(camadaFala != null)
                camadaFala.SetActive(false);
            if(camadaPersonagens != null)
                camadaPersonagens.SetActive(false);
            _arma = palyer.arma.GetComponent<Arma>();
            balasRestantes = _arma.numeroBala;
            sliderInimigo.enabled = false;
            
            if (camadaMenu == null) return;
            
            for(var i = 0; i < camadaMenu.transform.childCount ;i++)
                camadaMenu.transform.GetChild(i).gameObject.SetActive(false);
            menuMono = camadaMenu.transform.GetChild(0).gameObject;
            menuMapa = camadaMenu.transform.GetChild(1).gameObject;
            menuPresente = camadaMenu.transform.GetChild(2).gameObject;
            menuRegra = camadaMenu.transform.GetChild(3).gameObject;
            menuConfiguracao = camadaMenu.transform.GetChild(4).gameObject;
        }

        public void MouseNormal()
        {
            Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.ForceSoftware);
        }

        public void MouseObjeto()
        {
            Cursor.SetCursor(cursorObjeto, vobj, CursorMode.ForceSoftware);
        }

        #endregion
        #region fala

        public void Click(RaycastHit hit)
        {
            Debug.Log("pos [" + pos + "] len[" + falas.Length + "]" + (falas.Length == pos));
            if (falas.Length == pos)
            {
                Debug.Log(hit.collider.name);
                di = hit.collider.GetComponent<Dialogo>();
                if (di != null)
                {
                    falas = Fala.ApartirDeArquivo(di.caminhoFala);
                    SistemaFala.Instancia.pareDeFalar();
                    pos = 0;
                    SistemaFala.Instancia.Fale(falas[pos++]);
                }
            }
            else
            {
                if(SistemaFala.Instancia.estaFalando && ! SistemaFala.Instancia.esperando)
                    SistemaFala.Instancia.Pular();
                else
                    SistemaFala.Instancia.Fale(falas[pos++]);
            }
            
        }

        public void Click()
        {
            Debug.Log("pos [" + pos + "] len[" + falas.Length + "]");
            if (pos < falas.Length)
            {
                if(SistemaFala.Instancia.estaFalando && ! SistemaFala.Instancia.esperando)
                    SistemaFala.Instancia.Pular();
                else
                    SistemaFala.Instancia.Fale(falas[pos++]);
            }
            else
            {
                falas = new Fala[0];
                pos = 0;
                SistemaFala.Instancia.pareDeFalar();
                camadaFala.SetActive(false);
            }
        }

        #endregion

        #region estatisicas

        public Slider sliderInimigo;
        public int balasRestantes;
        public int balasDisparadas;
        public int balasAcertadas;
        public int balasHS;
        public int abates;
        
        public void mudaHorda(int n)
        {
            horda.text = n.ToString();
            Estatisticas();
        }
        public void Dispara()
        {
            ++balasDisparadas;
            --balasRestantes;
            Estatisticas();
        }
        public void DisparoAcerto()
        {
            ++balasAcertadas;
            Estatisticas();
        }
        public void DisparoHS()
        {
            ++balasHS;
            Estatisticas();
        }

        public void InimigoDano(float vidaAtual, float vidaMax)
        {
            sliderInimigo.enabled = true;
            sliderInimigo.minValue = 0f;
            sliderInimigo.maxValue = vidaMax;
            sliderInimigo.value = vidaAtual;
        }
        public void Abate()
        {
            ++abates;
            Estatisticas();
        }
        private void Estatisticas()
        {
            balas.text = balasRestantes.ToString(CultureInfo.InvariantCulture);
            kill.text = abates.ToString(CultureInfo.InvariantCulture);
            if (balasAcertadas == 0) return;
            precisao.text = Math.Round((float) balasAcertadas*100/ balasDisparadas,2).ToString(CultureInfo.InvariantCulture) + "%";
            if(balasHS != 0)
                hs.text = Math.Round((float) balasHS*100 /balasDisparadas,2) .ToString(CultureInfo.InvariantCulture);
        }
        #endregion

        public void Salva()
        {
            PlayerPrefs.SetInt("balasRestantes", balasRestantes);
            PlayerPrefs.SetInt("kill",abates);
            PlayerPrefs.SetFloat("precisao",(float)Math.Round((float) balasAcertadas*100/ balasDisparadas,2));
            PlayerPrefs.SetFloat("hs",(float)Math.Round((float) balasHS*100 /balasDisparadas,2));
        }

        public int NumeroBalas
        {
            get => palyer.arma.GetComponent<Arma>().numeroBala;
            set
            {
                palyer.arma.GetComponent<Arma>().numeroBala = value;
                Estatisticas();
            }
        }

        public float Cadencia
        {
            get => palyer.arma.GetComponent<Arma>().cadencia;
            set
            {
                palyer.arma.GetComponent<Arma>().cadencia = value;
                Estatisticas();
            }
        }

        public GameObject Bala
        {
            get => palyer.arma.GetComponent<Arma>().bala;
            set
            {
                palyer.arma.GetComponent<Arma>().bala = value;
                Estatisticas();
            }
        }
        
    }
}