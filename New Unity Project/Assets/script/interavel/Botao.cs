using UnityEditor;
using UnityEngine;

using Solucao.script.belico;
using Solucao.script.interavel.atiravel;
namespace Solucao.script.interavel
{
    public class Botao : Atiravel,Acionavel
    {
        public GameObject alvo;
        public string nome;
        public bool ativado = true;
        public bool unico = true;

        public void AoDisparo(Bala bala)
        {
            if (ativado)
            {
                if (unico)
                {
                    ativado = false;
                }
                Debug.Log("botão");
                alvo.SendMessage("AoAcionar");
            }
            
        }

        public void AoAcionar()
        {
            ativado = !ativado;
        }

        public void MudaAlvo(GameObject go)
        {
            alvo = go;
        }
    }
}