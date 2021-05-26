using codigo.ui;
using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxMunicao : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;
        public static string Efeito =>  "balas adicionais";
        private void Awake()
        {
            _lootBox = this;
        }
        public static void AoAcionar()
        {
            Mundo.Instancia.NumeroBalas += Gerenciador.Instancia.balasIniciais;
        }
    }
}