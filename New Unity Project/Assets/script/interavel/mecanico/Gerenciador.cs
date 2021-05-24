using System;
using System.Collections.Generic;
using System.Xml;
using codigo.ui;
using codigo.ui.botao;
using Solucao.script.interavel.atiravel.tangivel;
using Solucao.script.interavel.box;
using UnityEngine;
using Random = System.Random;

namespace Solucao.script.interavel.mecanico
{
    [Serializable]
    public class Gerenciador : MonoBehaviour
    {
        private static Gerenciador _gerenciador;

        public static Gerenciador Instancia => _gerenciador;
        public int balasIniciais;
        public float cadenciaInicial;
        public float daninho;
        public float escala;
        public float cura;
        [HideInInspector] public Vector3 Escala;
        public GeraAlvo[] geradores;
        public GameObject inimigo;
        public GameObject loot;
        private Zumbi _zumbi;
        private int level;
        public int quantidade;
        public int numero;
        public float velocidade;
        public float danoZumbi;
        public float vida;
        private Random rng = new Random();
        
        private void Awake()
        {
            _gerenciador = this;
            geradores = FindObjectsOfType<GeraAlvo>();
            _zumbi = inimigo.GetComponent<Zumbi>();
            quantidade = 1;
            velocidade = 1;
            danoZumbi = 5;
            vida = 100;
            level = 1;
            numero = 0;
        }

        private void Start()
        {
            Mundo.Instancia.NumeroBalas = balasIniciais;
            Mundo.Instancia.Cadencia = cadenciaInicial;
            Escala = new Vector3(escala, escala, escala);
            AtualizaGeradores();
            gerar();
        }

        public void ProximoLevel()
        {
            ++level;
            Mundo.Instancia.mudaHorda(level);
            quantidade += (int)Math.Ceiling((float)quantidade/3);
            velocidade += velocidade/4;
            vida += vida / 10;
            AtualizaGeradores();
            gerar();
        }

        public void Kill()
        {
            Mundo.Instancia.Abate();
            LimpaLoot(loot);
            LootBox(loot);
            Proximo.Cria(loot);
            ++numero;
            if(numero>=quantidade)
                ProximoLevel();
        }

        public void LimpaLoot(GameObject go)
        {
        }

        private void gerar()
        {
            numero = 0;
            for (var n = 0; n < quantidade; n++)
                Proximo.Cria(inimigo);
        }
        
        

        private GeraAlvo Proximo => geradores[rng.Next(geradores.Length)];

        public void LootBox(GameObject go)
        {
            
        }
        private void AtualizaGeradores()
        {
            _zumbi.VidaMax = vida;
            _zumbi.Dano = danoZumbi;
            _zumbi.Velocidade = velocidade;
            foreach (var gerador in geradores)
            {
                gerador.MudaAlvo(inimigo);
            }
        }

        
    }
}