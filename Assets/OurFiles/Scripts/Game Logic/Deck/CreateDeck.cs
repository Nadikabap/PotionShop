using Game_Logic.CardLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Deck
{
	public class CreateDeck : MonoBehaviour
	{
		[SerializeField] private int _requaredCount;
		[SerializeField] private List<Card> _cards;

		private void OnValidate()
		{
			switch (gameObject.name)
			{
				case "RedDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Red);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Red);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
				case "GreenDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Green);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Green);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
				case "BlueDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Blue);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Blue);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
				case "YellowDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Yellow);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Yellow);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
			}
		}

		public Card GetCard(int index)
		{
			return _cards[index];
		}

		public int CountCardsInList()
		{
			return _cards.Count;
		}
	}
}