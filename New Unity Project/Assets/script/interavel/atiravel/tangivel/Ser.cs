using UnityEngine;

namespace Solucao.script.interavel.atiravel.tangivel
{
    [System.Serializable]
    public class Ser : MonoBehaviour
    {
        [Range(min:10,max:1000)]
        public float vidaMax;
        private float _vida;
        private bool _vivo;

        public float VidaMax
        {
            get => vidaMax;
            set
            {
                vidaMax = value;
                _vida = value;
            }
        }
        public void Nasce()
        {
            _vida = vidaMax;
            _vivo = true;
        }
        public float Vida
        {
            get => _vida;
            set
            {
                if(!_vivo)
                    return;
                _vida += value;
                if (_vida < 0)
                {
                    _vida = 0;
                    _vivo = false;
                }
                if (_vida > vidaMax)
                    _vida = vidaMax;
            }
        }

        public bool vivo
        {
            get => _vivo;
        }
    }
}