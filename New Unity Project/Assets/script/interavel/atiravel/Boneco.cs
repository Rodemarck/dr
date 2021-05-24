using System;
using UnityEditor;
using UnityEngine;
using Solucao.script.belico;
using Solucao.script.interavel.mecanico;
namespace Solucao.script.interavel.atiravel
{
	public class Boneco : MonoBehaviour,Atiravel
	{
		public GeraAlvo gerador;

		public void AoDisparo(Bala bala)
        {
			gerador.Conta();
        }
	}
}

