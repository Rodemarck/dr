using System;
using codigo.ui.fala;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace codigo.ui
{
    
    [Serializable]
    [RequireComponent(typeof(SistemaFala))]
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
        #region Fala

        [Header("Sistema de fala")]
        public Text texto;

        public Text nome;
        public Text descricao;
        public GameObject painel;
        

        private Fala[] falas;
        private Dialogo di;
        private int pos=0;
        #endregion
        #region Cursor
        
        [FormerlySerializedAs("mouseNormal")]
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
        #endregion
        #region Construtor

        private void Start()
        {
            MouseNormal();
            descricao.enabled = false;
            falas = new Fala[0];
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
                painel.SetActive(false);
            }
        }

        #endregion
        
    }
}