using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.CardLogic
{
	public class TestStateChange : MonoBehaviour
	{
		private void Start()
		{
			CurrentState currentStateInDeck = new CurrentState(new StateInDeck());

			currentStateInDeck.InDeck();
		}
	}
}