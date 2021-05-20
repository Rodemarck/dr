using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
//using MongoDB.Bson;
//using MongoDB.Driver;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace codigo.dados
{
    [DisallowMultipleComponent]
    [Serializable]
    public class BD
    {
        [MenuItem("Coisas/log")]
        static void aa()
        {
            
           
        }
        public static async void post(string url, Dictionary<string, object> dicionario, Action<HttpStatusCode,string> acao)
        {   
            
            var dados = "";
            if (dicionario.Count > 0)
            {
                dados = dicionario.Aggregate(dados, (current, par) => current + par.Key + '=' + par.Value + '&');
                dados = dados.Substring(0, dados.Length - 1);
            }

            var data = Encoding.UTF8.GetBytes(dados);
            var requisicaoWeb = WebRequest.CreateHttp(url);
            var tex = "";
            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.ContentLength = data.Length;
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            //precisamos escrever os dados post para o stream
            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            } 
            Debug.Log("uu");
            using var resposta = (HttpWebResponse)requisicaoWeb.GetResponse();
            
            var streamDados = resposta.GetResponseStream();
            var reader = new StreamReader(streamDados);
            tex = reader.ReadToEnd();
            streamDados.Close();
            resposta.Close();
            acao(resposta.StatusCode, tex);
        }
        public static async void get(string url, Dictionary<string, object> dicionario, Action<HttpStatusCode,string> acao){
            var urlFinal = url + '?';
            if (dicionario.Count > 0)
            {
                urlFinal = dicionario.Aggregate(urlFinal, (current, par) => current + par.Key + '=' + par.Value + '&');
                urlFinal = urlFinal.Substring(0, urlFinal.Length - 1);
            }
            
            var requisicaoWeb = WebRequest.CreateHttp(urlFinal);
            var tex = "";
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using var resposta = (HttpWebResponse)requisicaoWeb.GetResponse();
            var streamDados = resposta.GetResponseStream();
            var reader = new StreamReader(streamDados);
            tex = reader.ReadToEnd();
            streamDados.Close();
            resposta.Close();
            acao(resposta.StatusCode, tex);
        }

       
        
    }
}