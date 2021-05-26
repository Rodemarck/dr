using codigo.ui;
using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxVida : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;
        public static string Efeito => "aumento de vida máxima";
        private void Awake()
        {
            _lootBox = this;
            
        }
        public static void AoAcionar()
        {
            Mundo.Instancia.palyer.VidaMax += Gerenciador.Instancia.cura;
        }

       
    }
}