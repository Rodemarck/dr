using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    [RequireComponent(typeof(BoxCollider))]
    public class LootBox : MonoBehaviour,Acionavel
    {
        public int n;
        public string efeito;
        public void AoAcionar(){
            switch (n)
            {
                case 0:
                    BoxVida.AoAcionar();
                    efeito = BoxVida.Efeito;
                    break;
                case 1:
                    BoxBala.AoAcionar();
                    efeito = BoxBala.Efeito;
                    break;
                case 2:
                    BoxCadencia.AoAcionar();
                    efeito = BoxCadencia.Efeito;
                    break;
                case 3:
                    BoxMunicao.AoAcionar();
                    efeito = BoxMunicao.Efeito;
                    break;
                case 4:
                    BoxVelocidade.AoAcionar();
                    efeito = BoxVelocidade.Efeito;
                    break;
            }
            Destroy(gameObject);
        }
        public  void MudaAlvo(GameObject go){}
        
    }
}