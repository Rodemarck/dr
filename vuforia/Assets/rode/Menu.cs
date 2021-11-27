using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Menu : MonoBehaviour
{
    int numero;
    public Camera _camera;
    void Start(){
        numero = 0;
    }

    private void Update()
    {
       
    }

    public void aparece(){
        Debug.Log(numero);
        if(++numero == 5){
            Debug.Log("inicia o jogo");
            
        }
    }
}
