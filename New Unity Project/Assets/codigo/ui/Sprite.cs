using System;
using codigo.dados;
using UnityEngine;

namespace codigo.ui
{
    public class Sprite
    {
        public GameObject go;
        public int x;
        public int y;

        public Sprite(string caminho, int x, int y)
        {
            go = Resources.Load("Assets/recursos/prefabs/" + caminho) as GameObject;
            this.x = x;
            this.y = y;
        }
        public static Sprite Cria(string texto)
        {
            var args = texto.Split(',');
            return new Sprite(args[0], int.Parse(args[1]), int.Parse(args[2]));
        }
    }
}