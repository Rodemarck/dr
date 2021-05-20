using MongoDB.Bson;
using UnityEngine;

namespace codigo.dados
{
    public class Conta
    {
        private ObjectId _id;
        private string login;
        private string email;
        private string senha;

        public Conta(string login, string email, string senha)
        {
            this.login = login;
            this.email = email;
            this.senha = senha;
        }

        public override string ToString()
        {
            return "Conta(" + "_id=" + _id + "; login=" + login + "; email=" + email + ")";
        }

        public static Conta fromJson(string str)
        {
            return JsonUtility.FromJson<Conta>(str);
        }
    }
}