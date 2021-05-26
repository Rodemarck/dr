using codigo.ui;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxVelocidade : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;
        public static string Efeito => "aumento e velocidade";
        private void Awake()
        {
            _lootBox = this;
        }
        public static void AoAcionar()
        {
            
            Mundo.Instancia.palyer.velocidade += 1f;
        }
    }
}