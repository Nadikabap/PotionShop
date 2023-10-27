using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.CardLogic
{
	public class StateInDeck : CardState
	{
		public override void Handle1()
		{
			Debug.Log("Handle1 StateInDeck");
		}

		public override void Handle2()
		{
			Debug.Log("Handle2 StateInDeck");
		}

		public override void Handle3()
		{
			Debug.Log("Handle3 StateInDeck");
		}
	}
}