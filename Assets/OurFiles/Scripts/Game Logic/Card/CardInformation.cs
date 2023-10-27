using System.Collections;
using UnityEngine;

namespace Game_Logic.CardLogic
{
	public class CardInformation : MonoBehaviour
	{
		[SerializeField] private int _points;
		[SerializeField] private CardColor _cardColor;
		[SerializeField] private CardBonusType _bonusType;
		[SerializeField] private BonusColor _bonusColor;

		[SerializeField] private Sprite _cardSprite;
		[SerializeField] private Sprite _cardColorSprite;
		[SerializeField] private Sprite _cardBonusColorSprite;

		public void SetPoints(int points) => _points = points;
		public void SetCardColor(CardColor cardColor) => _cardColor = cardColor;
		public void SetCardBonusType(CardBonusType bonusType) => _bonusType = bonusType;
		public void SetCardBonusColor(BonusColor bonusColor) => _bonusColor = bonusColor;

		public int GetPoints() => _points;
		public CardColor GetCardColor() => _cardColor;
		public CardBonusType GetBonusType() => _bonusType;
		public BonusColor GetBonusColor() => _bonusColor;


		public void SetCardSprite(Sprite cardSprite) => _cardSprite = cardSprite;
		public void SetCardColorSprite(Sprite cardColorSprite) => _cardColorSprite = cardColorSprite;
		public void SetCardBonusColorSprite(Sprite cardBonusColorSprite) => _cardBonusColorSprite = cardBonusColorSprite;

		public Sprite GetCardSprite() => _cardSprite;
		public Sprite GetCardColorSprite() => _cardColorSprite;
		public Sprite GetCardBonusColorSprite() => _cardBonusColorSprite;
	}
}