using codigo.ui;
using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxVida : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;

        private void Awake()
        {
            _lootBox = this;
            efeito = "aumento de vida máxima";
        }
        public override void AoAcionar()
        {
            Mundo.Instancia.palyer.VidaMax += Gerenciador.Instancia.cura;
            Destroy(gameObject);
        }

       
    }
}