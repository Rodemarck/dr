using codigo.ui;
using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxCadencia : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;

        private void Awake()
        {
            _lootBox = this;
            efeito = "aumento na cadencia de disparo";
        }
        public override void AoAcionar()
        {
            Mundo.Instancia.Cadencia += Gerenciador.Instancia.cadenciaInicial/3;
            Destroy(gameObject);
        }
    }
}