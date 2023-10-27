using Data;
using System.Collections.Generic;
using TMPro;
using Game_Logic.CardLogic;
using UnityEngine;
using UnityEngine.UI;


namespace Game_Logic.Deck
{
[RequireComponent(typeof(CreateDeck))]
	public class TopCard : MonoBehaviour
	{
		[SerializeField] private GameObject _cardPrefab;
		[SerializeField] private DataCard _dataCard;
		[SerializeField] private CreateDeck _createDeck;

		[SerializeField] private List<Card> _deck;
		private Sprite _cardImage;
		private Sprite _cardColorImage;
		private Sprite _bonusImage;
		private int _bonusPosition;
		private int _point;
		private CardColor _cardColor;
		private CardBonusType _bonusType;
		private BonusColor _bonusColor;

		private void OnValidate()
		{
			_dataCard = FindObjectOfType<DataCard>();
			_createDeck = gameObject.GetComponent<CreateDeck>();
		}

		private void Start()
		{
			GetDeck();
			FlipCardOnTopDeck();
		}

		public void FlipCard() => FlipCardOnTopDeck();
		public List<Card> GetDeckValues() => _deck;
		private void GetDeck()
		{
			for (int i = 0; i < _createDeck.CountCardsInList(); i++)
			{
				_deck.Add(_createDeck.GetCard(i));
			}

			_deck = SortDeckWithBlackCards(_deck);
		}
		private List<Card> SortDeckWithBlackCards(List<Card> cards)
		{
			int countBlackCards = 0;
			for (int i = 0; i < cards.Count; i++)
			{
				if (cards[i].GetColor() == CardColor.Black) countBlackCards++;
			}

			for (int i = cards.Count - countBlackCards; i < cards.Count; i++)
			{
				int indexForBlackCard = Random.Range(1, i);

				if (indexForBlackCard == i - 1)
				{
					if (cards[indexForBlackCard - 1].GetColor() != CardColor.Black)
					{
						Card bufer = cards[indexForBlackCard];
						cards[indexForBlackCard] = cards[i];
						cards[i] = bufer;
					}
					else
					{
						i--;
					}
				}
				else
				{
					if (cards[indexForBlackCard - 1].GetColor() != CardColor.Black && cards[indexForBlackCard + 1].GetColor() != CardColor.Black
						&& cards[indexForBlackCard].GetColor() != CardColor.Black)
					{
						Card bufer = cards[indexForBlackCard];
						cards[indexForBlackCard] = cards[i];
						cards[i] = bufer;
					}
					else
					{
						i--;
					}
				}
			}

			return cards;
		}
		private void FlipCardOnTopDeck()
		{
			if (_deck.Count > 0)
			{
				// Для тестов
				/*if (gameObject.transform.childCount > 0)
					Destroy(gameObject.transform.GetChild(0).gameObject);*/

				LoadCardInformationFromData();
				InstantiateCardOnTopDeck();
			}
		}

		// Нужно будет потом изменить под выбор конкретной карты
		private void LoadCardInformationFromData()
		{
			Card card = _deck[0];

			LoadImage(card);
			LoadColor(card);
			LoadBonus(card);
			LoadPoint(card);

			DeleteTopCardForDeck(_deck[0]);
		}

		// Загрузка информации с выбранной карты
		private void LoadImage(Card card)
		{
			int countImage;
			switch (card.GetColor())
			{
				case CardColor.Red:
					countImage = Random.Range(0, _dataCard.redCardImage.Count);
					_cardImage = _dataCard.redCardImage[countImage];
					break;
				case CardColor.Green:
					countImage = Random.Range(0, _dataCard.greenCardImage.Count);
					_cardImage = _dataCard.greenCardImage[countImage];
					break;
				case CardColor.Blue:
					countImage = Random.Range(0, _dataCard.blueCardImage.Count);
					_cardImage = _dataCard.blueCardImage[countImage];
					break;
				case CardColor.Yellow:
					countImage = Random.Range(0, _dataCard.yellowCardImage.Count);
					_cardImage = _dataCard.yellowCardImage[countImage];
					break;
				case CardColor.Black:
					countImage = Random.Range(0, _dataCard.blackCardImage.Count);
					_cardImage = _dataCard.blackCardImage[countImage];
					break;
			}
		}
		private void LoadColor(Card card)
		{
			switch (card.GetColor())
			{
				case CardColor.Red:
					_cardColor = CardColor.Red;
					foreach (Sprite item in _dataCard.cardTypeImage)
					{
						if (item.name == "Red")
						{
							_cardColorImage = item;
						}
					}
					break;
				case CardColor.Green:
					_cardColor = CardColor.Green;
					foreach (Sprite item in _dataCard.cardTypeImage)
					{
						if (item.name == "Green")
						{
							_cardColorImage = item;
						}
					}
					break;
				case CardColor.Blue:
					_cardColor = CardColor.Blue;
					foreach (Sprite item in _dataCard.cardTypeImage)
					{
						if (item.name == "Blue")
						{
							_cardColorImage = item;
						}
					}
					break;
				case CardColor.Yellow:
					_cardColor = CardColor.Yellow;
					foreach (Sprite item in _dataCard.cardTypeImage)
					{
						if (item.name == "Yellow")
						{
							_cardColorImage = item;
						}
					}
					break;
				case CardColor.Black:
					_cardColor = CardColor.Black;
					foreach (Sprite item in _dataCard.cardTypeImage)
					{
						if (item.name == "Black")
						{
							_cardColorImage = item;
						}
					}
					break;
				default:
					Debug.Log("Ошибка в цвете");
					break;
			}
		}
		private void LoadBonus(Card card)
		{
			switch (card.GetBonusColor())
			{
				case BonusColor.Red:
					_bonusColor = BonusColor.Red;
					foreach (Sprite item in _dataCard.bonusImage)
					{
						if (item.name == "Red")
						{
							_bonusImage = item;
						}
					}
					break;
				case BonusColor.Green:
					_bonusColor = BonusColor.Green;
					foreach (Sprite item in _dataCard.bonusImage)
					{
						if (item.name == "Green")
						{
							_bonusImage = item;
						}
					}
					break;
				case BonusColor.Blue:
					_bonusColor = BonusColor.Blue;
					foreach (Sprite item in _dataCard.bonusImage)
					{
						if (item.name == "Blue")
						{
							_bonusImage = item;
						}
					}
					break;
				case BonusColor.Yellow:
					_bonusColor = BonusColor.Yellow;
					foreach (Sprite item in _dataCard.bonusImage)
					{
						if (item.name == "Yellow")
						{
							_bonusImage = item;
						}
					}
					break;
				case BonusColor.Black:
					_bonusColor = BonusColor.Black;
					foreach (Sprite item in _dataCard.bonusImage)
					{
						if (item.name == "Black")
						{
							_bonusImage = item;
						}
					}
					break;
			}

			switch (card.GetBonusType())
			{
				case CardBonusType.Left:
					_bonusType = CardBonusType.Left;
					_bonusPosition = 2;
					break;
				case CardBonusType.Center:
					_bonusType = CardBonusType.Center;
					_bonusPosition = 3;
					break;
				case CardBonusType.Right:
					_bonusType = CardBonusType.Right;
					_bonusPosition = 4;
					break;
				case CardBonusType.LeftAndRight:
					_bonusType = CardBonusType.LeftAndRight;
					_bonusPosition = 5;
					break;
			}
		}
		private void LoadPoint(Card card)
		{
			_point = card.GetPoint();
		}

		// Создание карты сверху колоды и передача туда загруженной информации
		private void InstantiateCardOnTopDeck()
		{
			GameObject card = Instantiate(_cardPrefab, gameObject.transform.position, Quaternion.identity);
			card.transform.SetParent(gameObject.transform);
			card.transform.localScale = transform.localScale;

			SetCardInformation(card);
		}
		private void SetCardInformation(GameObject card)
		{
			//card.GetComponent<Image>().sprite = _cardImage;
			//card.transform.GetChild(0).GetComponent<Image>().sprite = _cardColorImage;
			//card.transform.GetChild(_bonusPosition).GetComponent<Image>().sprite = _bonusImage;
			//card.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _point.ToString();
			CardInformation cardInformation = card.GetComponent<CardInformation>();

			cardInformation.SetPoints(_point);
			cardInformation.SetCardColor(_cardColor);
			cardInformation.SetCardBonusType(_bonusType);
			cardInformation.SetCardBonusColor(_bonusColor);

			cardInformation.SetCardSprite(_cardImage);
			cardInformation.SetCardColorSprite(_cardColorImage);
			cardInformation.SetCardBonusColorSprite(_bonusImage);

			card.GetComponent<UpdateVisualCardInformation>().UpdateCardInformation();
		}
		private void DeleteTopCardForDeck(Card card)
		{
			_deck.Remove(card);
		}
	}
}