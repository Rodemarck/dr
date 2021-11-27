using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using rode.codigo;
using UnityEditor;
using UnityEngine;
[System.Serializable]
[RequireComponent(typeof(ControladorFala))]
public class Mundo : MonoBehaviour
{
    #region Singleton
    
    private static Mundo _mundo;
    public static Mundo Instancia
    {
        get => _mundo;
    }

    private void Awake()
    {
        _controladorFala = GetComponent<ControladorFala>();
        _camera = GameObject.Find("ARCamera").GetComponent<Camera>();
        _mundo = this;
        //Mundo.Instancia.ControladorFala.txtHistoria.transform.position = new Vector3(1f,0f,0f);
        //Debug.Log( Mundo.Instancia.ControladorFala.txtHistoria.rectTransform.position);
        //Debug.Log(LoadJson("./../recursos/falas.json"));
    }
   
    #endregion

    #region Campo

    private ControladorFala _controladorFala;

    public ControladorFala ControladorFala
    {
        get => _controladorFala;
    }

    private Camera _camera;
    public Camera Camera { get => _camera; }

    #endregion

    public void vizualizaAlvo(Alvo.TipoAlvo tipoAlvo)
    {
         switch (tipoAlvo)
         {
            case Alvo.TipoAlvo.A: break;
            case Alvo.TipoAlvo.B: break;
            case Alvo.TipoAlvo.C: break;
            case Alvo.TipoAlvo.PROXIMO: break;
            case Alvo.TipoAlvo.ANTERIOR: break;
            case Alvo.TipoAlvo.MENU: break;
            default: break;
         }
    }

    public void fimJogo()
    {
        Application.Quit();
    }
}
