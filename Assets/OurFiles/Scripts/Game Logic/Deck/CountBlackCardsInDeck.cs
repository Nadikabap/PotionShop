using Game_Logic.CardLogic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game_Logic.Deck
{
	public class CountBlackCardsInDeck : MonoBehaviour
	{
		[SerializeField] private TopCard _topCard;

		[SerializeField] private TextMeshProUGUI _countCards;
		[SerializeField] private TextMeshProUGUI _countBlackCards;

		private void Awake()
		{
			_topCard = GetComponent<TopCard>();
		}

		private void Update()
		{
			_countCards.text = _topCard.GetDeckValues().Count.ToString();

			List<Card> currentDeck = _topCard.GetDeckValues();
			int countBlackCards = 0;
			for (int i = 0; i < currentDeck.Count; i++)
			{
				if (currentDeck[i].GetColor() == CardColor.Black)
				{
					countBlackCards++;
				}
			}
			_countBlackCards.text = countBlackCards.ToString();
		}
	}
}