using System;
using JetBrains.Annotations;
using MongoDB.Bson;

namespace codigo.dados
{
    public class Personagem
    {
        public string conta_id;
        public string nome;

        public Personagem( string contaID, string nome)
        {
            conta_id = contaID ;
            this.nome = nome;
        }
    }
}