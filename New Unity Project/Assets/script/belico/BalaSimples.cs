using UnityEditor;
using UnityEngine;
using System;
using Solucao.script.interavel.atiravel;

namespace Solucao.script.belico
{
    public class BalaSimples : Bala
    {
        void Update()
        {
            UpdateBala();
        }
        public override void AoColidir(Collision collision)
        {
            
            try
            {
                var at = collision.gameObject.GetComponent<Atiravel>();
                if (at != null)
                {
                    //Debug.Log("colidindon com " + collision.gameObject.name);
                    at.AoDisparo(this);
                }
                Destroy(gameObject);
            }
            catch (Exception e)
            {
                // ignored
            }
            //Destroy(this.gameObject);
        }
    }
}