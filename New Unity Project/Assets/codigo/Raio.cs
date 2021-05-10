using System;
using codigo.ui.fala;
using UnityEngine;
using UnityEngine.EventSystems;

namespace codigo
{
    public class Raio : MonoBehaviour
    {
        private RaycastHit hit;
        private Ray raio;
        public Transform alvo;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(SistemaFala.Instancia.estaFalando)
                    Mundo.Instancia.Click();
                else if (!EventSystem.current.IsPointerOverGameObject())
                {
                    raio = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(raio, out hit))
                    {
                        Mundo.Instancia.Click(hit);
                    }
                }
            }
            
        }
    }
}