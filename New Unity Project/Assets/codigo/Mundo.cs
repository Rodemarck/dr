using System;
using UnityEngine;

namespace codigo
{
    
    [System.Serializable]
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
        #region Cursor
        [Header("Cursor do mouse")]
        public Texture2D mouseNormal;

        #endregion

        #endregion

        #region Construtor

        private void Update()
        {
            Cursor.SetCursor(mouseNormal, Vector2.zero, CursorMode.ForceSoftware);
        }

        #endregion
    }
}