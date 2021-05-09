using System;
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
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                raio = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(raio, out hit,20))
                {
                    //hit.collider.gameObject;
                    Debug.Log("ACHEI VOCE!!!");
                }
                else
                {
                    Debug.Log("porra!!!");
                }
            }
        }

        private Vector3 AnguloMouse()
        {
            float angX, angY;
            if (Input.mousePosition.x == Dados.width)
                angX = 45;
            else if (Input.mousePosition.x == -Dados.width)
                angX = -45;
            else
                angX = ((Input.mousePosition.x - Dados.width) / Dados.width);
            
            if (Input.mousePosition.y == Dados.height)
                angY = 45;
            else if (Input.mousePosition.y == -Dados.height)
                angY = -45;
            else
                angY = ((Input.mousePosition.y - Dados.height) / Dados.height);
            return new Vector3(-angX, 0,angY);
        }
    }
}