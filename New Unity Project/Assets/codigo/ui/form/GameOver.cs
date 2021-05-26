using System;
using UnityEngine;
using UnityEngine.UI;

namespace codigo.ui.form
{
    public class GameOver : MonoBehaviour
    {
        public Text precisao;
        public Text abates;
        public Text hs;

        private void Start()
        {
            precisao.text += PlayerPrefs.GetFloat("precisao") + "%";
            abates.text += PlayerPrefs.GetInt("kill");
            hs.text += PlayerPrefs.GetFloat("hs");
        }
    }
}