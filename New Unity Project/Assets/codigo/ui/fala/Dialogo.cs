using System;
using UnityEngine;

namespace codigo.ui.fala
{
    [System.Serializable]
    public class Dialogo : MonoBehaviour
    {
        public string caminhoFala;

        private void OnMouseEnter()
        {
            Mundo.Instancia.MouseObjeto();
        }

        private void OnMouseExit()
        {
            Mundo.Instancia.MouseNormal();
        }
    }
}