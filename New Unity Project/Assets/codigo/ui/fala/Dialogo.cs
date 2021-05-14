using System;
using UnityEngine;

namespace codigo.ui.fala
{
    [System.Serializable]
    public class Dialogo : MonoBehaviour
    {
        public string caminhoFala;
        public string descricao;

        private void OnMouseEnter()
        {
            Mundo.Instancia.descricao.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0,1f,0));
            Mundo.Instancia.descricao.text = descricao;
            Mundo.Instancia.descricao.enabled = true;
            Mundo.Instancia.MouseObjeto();
            Debug.Log("enable = " + Mundo.Instancia.descricao.enabled);
        }

        private void OnMouseExit()
        {
            Mundo.Instancia.descricao.enabled = false;
            Mundo.Instancia.MouseNormal();
            Debug.Log("enable = " + Mundo.Instancia.descricao.enabled);
        }
    }
}