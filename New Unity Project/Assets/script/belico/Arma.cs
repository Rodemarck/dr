using codigo.ui;
using UnityEditor;
using UnityEngine;

using Solucao.script.interavel;

namespace Solucao.script.belico
{
    [System.Serializable]
    public class Arma : MonoBehaviour
    {
        public GameObject cano;
        public GameObject bala;
        public float potencia;
        public float precisao;
        public float cadencia;
        public float velocidadeProjetil;
        public int numeroBala;

        public bool estaAtirando
        {
            get { return IsInvoking(nameof(Disparo)); }
        }
        
        public void Atirar()
        {
            Debug.Log(1f / cadencia);
            if (estaAtirando) return;
            Debug.Log("Abrindo fogo");
            InvokeRepeating(nameof(Disparo), 0.5f,1/cadencia);

        }
        public void Cessar()

        {
            Debug.Log("cessar");
            if (estaAtirando)
            {
                CancelInvoke(nameof(Disparo));
            }
        }

        private void Update()
        {
            // Debug.Log(cano.transform.parent.forward);
            // Debug.Log(cano.transform.parent.forward);
        }

        private void Disparo()
        {
            if (numeroBala <= 0) return;
            numeroBala--;
            Mundo.Instancia.Dispara();
            var temp = Instantiate(bala, cano.transform.position,Quaternion.identity);
            temp.GetComponent<BalaSimples>().Potencia = potencia;
            temp.transform.position = cano.transform.position;
            temp.GetComponent<Rigidbody>().AddForce(cano.transform.parent.forward * velocidadeProjetil * 100);
        }
    }
}