using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Alvo : MonoBehaviour
{
    public enum TipoAlvo
    {
        PROXIMO,
        ANTERIOR,
        MENU,
        A,
        B,
        C
    }
    #region campos
    
    public TipoAlvo _TipoAlvo;
    
    #endregion

    #region metodos

    public void acao()
    {
        Mundo.Instancia.vizualizaAlvo(_TipoAlvo);
    }

    #endregion

    /*{
             var pos = Mundo.Instancia.Camera.WorldToScreenPoint(transform.position);
             Mundo.Instancia.ControladorFala.txtHistoria.transform.position = new Vector3(pos.x-200f,pos.y)/2.65f;
             Debug.Log(pos);
    }*/
}
