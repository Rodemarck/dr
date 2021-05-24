using System;
using Solucao.script.interavel.atiravel.tangivel;
using UnityEditor;
using UnityEngine;
using Solucao.script.ui;
using Mundo = codigo.ui.Mundo;

namespace Solucao.script.interavel.mecanico
{
    [System.Serializable]
    public class GeraAlvo : MonoBehaviour, Acionavel
    {
        public GameObject alvo;
        public float timer;
        public int cota = 0;
        private int numero = 0;
        public int n = 0;
        public bool ativado = false;
        public void AoAcionar()
        {
            ativado = true;
            Gerar();
        }


        public void Gerar()
        {
            ++numero;
            Instantiate(alvo);
        }

        public void Cria(GameObject go)
        {
            var obj = Instantiate(go);
            obj.transform.position = transform.position;
            //obj.GetComponent<Zumbi>().geraAlvo = this;
            MudaAlvo(obj);
        }
        
        public void MudaAlvo(GameObject go)
        {
            alvo = go;
        }
        public void Conta()
        {
            ++n;
            GerenciadorMundo.Instancia.Kill();
            if(n >= cota)
                GerenciadorMundo.Instancia.RealizaObjetivo();
        }
    }
}