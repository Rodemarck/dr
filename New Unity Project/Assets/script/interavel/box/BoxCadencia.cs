using codigo.ui;
using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxCadencia : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;
        public static string Efeito =>"aumento na cadencia de disparo";
        private void Awake()
        {
            _lootBox = this;
        }
        public static void AoAcionar()
        {
            Mundo.Instancia.Cadencia += Gerenciador.Instancia.cadenciaInicial/3;
        }
    }
}