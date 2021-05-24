using Solucao.script.interavel.atiravel.tangivel;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;


namespace Solucao.script.ia
{
    [System.Serializable]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Perseguidor : Ser
    {
        [Range(min:0.1f,max:1)]
        public float distanciaMinima;
        [Range(min:15,max:50)]
        public float distanciaMax;
        public Transform alvo;
        private float distanciaAtual;
        public bool parar = false;

        public float Distancia
        {
            get => distanciaAtual;
        }
        protected NavMeshAgent _navMeshAgent;

        public void VelhoStart()
        {
            if (alvo == null)
            {
                alvo = GameObject.FindWithTag("Player").transform;
            }
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public void VelhoUpdate()
        {
            distanciaAtual = Vector3.Distance(transform.position, alvo.position);
            if(distanciaAtual <= distanciaMinima || distanciaAtual >= distanciaMax)
                return;
            _navMeshAgent.SetDestination(alvo.position);
            _navMeshAgent.isStopped = parar;
        }
    }
}