using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using codigo.dados;
using codigo.ui.fala;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace codigo.ui.form
{
    [DisallowMultipleComponent]
    public class Cadastro : MonoBehaviour
    {
        public GameObject form;
        
        private InputField login;
        private InputField senha;
        private InputField email;

        private void Start()
        {
            for (var x = 0; x < form.transform.childCount; x++)
            {
                if (form.transform.transform.GetChild(x).name == "login")
                    login = form.transform.transform.GetChild(x).GetComponent<InputField>();
                else if (form.transform.transform.GetChild(x).name == "senha")
                    senha = form.transform.transform.GetChild(x).GetComponent<InputField>();
                else if (form.transform.transform.GetChild(x).name == "email")
                    email = form.transform.transform.GetChild(x).GetComponent<InputField>();
            }
        }

        public void logar()
        {
            var dict = new Dictionary<string, string>();
            dict["login"] = login.text;
            dict["senha"] = senha.text;

            get("http://localhost:8080/conta/login", dict, (s, r) =>
            {
                 // Debug.Log(/97);
            });
        }

        public void vaiParaCadastro()
        {
            SceneManager.LoadScene("cena/menu/cadastro");
        }

        public void vaiParaLogin()
        {
            SceneManager.LoadScene("cena/menu/login");
        }

        public async void cadastra()
        {
            var dict = new Dictionary<string, string>();
            dict["login"] = login.text;
            dict["senha"] = senha.text;
            dict["email"] = email.text;
            
            try
            {
                post("http://localhost:8080/conta/cadastrar", dict, (s, r) =>
                {
                   
                });
                Debug.Log("foi-se");
            }
            catch (Exception e)
            {
                Debug.Log(e.Data.Keys.Count);
            }
        }
        public static async void get(string caminho, Dictionary<string, string> dicionario, Action<HttpStatusCode,string> acao)
        {
            var urlFinal = caminho + '?';
            if (dicionario.Count > 0)
            {
                urlFinal = dicionario.Aggregate(urlFinal, (current, par) => current + par.Key + '=' + par.Value + '&');
                urlFinal = urlFinal.Substring(0, urlFinal.Length - 1);
            }
            Debug.Log("aa");
            using var client = new HttpClient();
            Debug.Log("bb");
            using var response = await client.GetAsync(urlFinal);
            Debug.Log("cc");
            using var content = response.Content;
            Debug.Log("dd");
            var data = await content.ReadAsStringAsync();
            Debug.Log("ee");
            acao(response.StatusCode, data);
        }

        public static async void post(string caminho, Dictionary<string, string> dicionario,Action<HttpStatusCode, string> acao)
        {
            var lista = dicionario.Select(key => new KeyValuePair<string, string>(key.Key, key.Value)).ToList();
            IEnumerable<KeyValuePair<string, string>> nha = new List< KeyValuePair<string, string> >(lista);
            HttpContent q = new FormUrlEncodedContent(nha);
            using var client = new HttpClient();
            using var response = await client.PostAsync(caminho, q);
            using var content = response.Content;
            var resposta = await content.ReadAsStringAsync();
            acao(response.StatusCode, resposta);
        }
        
        
    }
}