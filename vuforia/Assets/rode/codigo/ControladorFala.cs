using System.Collections;
using System.Collections.Generic;
using System.IO;
using rode.codigo;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ControladorFala : MonoBehaviour
{
    #region Campos
    public Text txtNome;
    public Text txtMsg;
    public GameObject painelOp;
    public GameObject OpA;
    public Text txtOpA;
    public GameObject OpB;
    public Text txtOpB;
    public GameObject OpC;
    public Text txtOpC;
    private int indice = 0;

    private List<Fala> falas;
    
    #endregion

    #region Metodos

    public List<Fala> LoadJson(string path)
    {
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            return JsonUtility.FromJson<List<Fala>>(json);
            //List<Progress.Item> items = JsonConvert.DeserializeObject<List<Progress.Item>>(json);
        }
    }

    public void ProximaFala()
    {
        if (falas[indice].opcoes != null) return;
        indice++;
        if (indice >= falas.Count)
            Mundo.Instancia.fimJogo();

        ExibeFala();
    }

    public void ExibeFala()
    {
        txtNome.text = falas[indice].nome;
        txtMsg.text = falas[indice].texto;
        if (falas[indice].opcoes == null)
        {
            painelOp.SetActive(false);
            return;
        }
        painelOp.SetActive(true);
        OpA.SetActive(false);
        OpB.SetActive(false);
        OpC.SetActive(false);
        var i = 0;
        foreach (KeyValuePair<string, int> par in falas[indice].opcoes)
        {
            switch (i++)
            {
                case 0:
                    OpA.SetActive(true);
                    txtOpA.text = par.Key;
                    break;
                case 1:
                    OpB.SetActive(true);
                    txtOpB.text = par.Key;
                    break;
                case 2:
                    OpC.SetActive(true);
                    txtOpC.text = par.Key;
                    break;
            }
        }
    }
    
    #endregion
}
