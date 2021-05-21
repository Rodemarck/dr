using System;
using System.Collections.Generic;
using MongoDB.Bson;
using UnityEngine;

namespace codigo.dados
{
    public class Conta
    {
        public string login;
        public string email;
        public string senha;
        public List<Personagem> personagens;

        public Conta(string login, string email, string senha)
        {
            this.login = login;
            this.email = email;
            this.senha = senha;
        }

        public override string ToString()
        {
            return "Conta(login=" + login + "; email=" + email + "; personagens =" + personagens +")";
        }

        public static Conta fromJson(string str)
        {
            return JsonUtility.FromJson<Conta>(str);
        }
    }
}