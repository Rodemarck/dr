using codigo.ui;
using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxMunicao : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;

        private void Awake()
        {
            _lootBox = this;
            efeito = "balas adicionais";
        }
        public override void AoAcionar()
        {
            Mundo.Instancia.NumeroBalas += Gerenciador.Instancia.balasIniciais;
            Destroy(gameObject);
        }
    }
}