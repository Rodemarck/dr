using System;
using codigo.ui;
using Solucao.script.belico;
using Solucao.script.interavel.mecanico;
using UnityEngine;

namespace Solucao.script.interavel.box
{
    public class BoxBala : LootBox
    {
        private static LootBox _lootBox;

        public static LootBox Instancia => _lootBox;
        public static string Efeito =>"aumento de dano";
        private void Awake()
        {
            _lootBox = this;
        }


        public static void AoAcionar()
        {
            var obj = Mundo.Instancia.Bala;
            var bala = obj.GetComponent<BalaSimples>();
            bala.dano += Gerenciador.Instancia.daninho;
            obj.transform.localScale += Gerenciador.Instancia.Escala;
            Mundo.Instancia.Bala = obj;
        }
        
    }
}