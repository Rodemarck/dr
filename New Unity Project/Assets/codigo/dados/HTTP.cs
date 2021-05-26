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
    public class HTTP
    {
        [MenuItem("Coisas/log")]
        static void aa()
        {
            
           
        }
        public static async void get(string caminho, Dictionary<string, string> dicionario, Action<HttpStatusCode,string> acao)
        {
            var urlFinal = caminho + '?';
            if (dicionario.Count > 0)
            {
                urlFinal = dicionario.Aggregate(urlFinal, (current, par) => current + par.Key + '=' + par.Value + '&');
                urlFinal = urlFinal.Substring(0, urlFinal.Length - 1);
            }
            using var client = new HttpClient();
            using var response = await client.GetAsync(urlFinal);
            using var content = response.Content;
            var data = await content.ReadAsStringAsync();
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