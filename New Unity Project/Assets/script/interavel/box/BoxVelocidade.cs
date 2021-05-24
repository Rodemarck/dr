using codigo.ui;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxVelocidade : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;

        private void Awake()
        {
            _lootBox = this;
            efeito = "aumento e velocidade";
        }
        public override void AoAcionar()
        {
            
            Mundo.Instancia.palyer.velocidade += 1f;
            Destroy(gameObject);
        }
    }
}