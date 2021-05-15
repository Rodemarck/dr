using System;
using UnityEngine;

namespace codigo.ui.menu
{
    public class MonoBotao :MonoBehaviour
    {
        public int index;
        private bool levantado;

        private void OnMouseEnter()
        {
            if (levantado)
                transform.position += new Vector3(0, 1);
        }

        public bool Levantado
        {
            get => levantado;
            set
            {
                if(value == levantado) return;
                if(value)
                    transform.position += new Vector3(0, 1);
                else
                    transform.position += new Vector3(0, -1);
                levantado = value;
            }
        }
    }
}