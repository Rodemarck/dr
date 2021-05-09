using System;
using UnityEngine;

namespace codigo
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class Personagem : MonoBehaviour
    {
        #region Campo

        [Header("")]
        
        public float velocidade;
        
        private Rigidbody rigidbody;

        #endregion
        #region Construtor

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        #endregion

        private void Update()
        {
            //transform.Translate();
        }
    }
}