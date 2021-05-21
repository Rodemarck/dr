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
        private Text erro;

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
                else if(form.transform.transform.GetChild(x).name == "erro")
                    erro =  form.transform.transform.GetChild(x).GetComponent<Text>();
                
            }

            if (erro != null)
                erro.enabled = false;
        }

        public void logar()
        {
            var dict = new Dictionary<string, string>();
            dict["login"] = login.text;
            dict["senha"] = senha.text;

            HTTP.get("http://localhost:8080/conta/login", dict, (s, r) =>
            {
                if (s != HttpStatusCode.OK) return;
                //PlayerPrefs.SetString("id",JsonConvert.DeserializeObject<BsonDocument>(r).GetElement("login").Value.AsString);
                PlayerPrefs.SetString("conta",r);
                SceneManager.LoadScene("cena/menu/main_menu");
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
                HTTP.post("http://localhost:8080/conta/cadastrar", dict, (s, r) =>
                {
                    if (s == HttpStatusCode.OK)
                        SceneManager.LoadScene("cena/menu/login");
                    else
                    {
                        erro.enabled = true;
                        erro.text = r;
                    }
                        
                });
            }
            catch (Exception e)
            {
                Debug.Log(e.Data.Keys.Count);
            }
        }
        
        
    }
}