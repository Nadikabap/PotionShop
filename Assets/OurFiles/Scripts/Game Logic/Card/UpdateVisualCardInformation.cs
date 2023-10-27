using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game_Logic.CardLogic
{
	public class UpdateVisualCardInformation : MonoBehaviour
	{
		[SerializeField] private Image _cardImage;
		[SerializeField] private Image _cardColorImage;
		[SerializeField] private Image _cardLeftTypeImage;
		[SerializeField] private Image _cardCenterTypeImage;
		[SerializeField] private Image _cardRightTypeImage;
		[SerializeField] private Sprite _bonusColorImage;
		[SerializeField] private TextMeshProUGUI _pointsText;

		[SerializeField] private CardInformation _cardInformation;
		private void Awake()
		{
			_cardInformation = GetComponent<CardInformation>();

			_cardImage = GetComponent<Image>();
			_cardColorImage = transform.GetChild(0).GetComponent<Image>();
			_cardLeftTypeImage = transform.GetChild(2).GetComponent<Image>();
			_cardCenterTypeImage = transform.GetChild(3).GetComponent<Image>();
			_cardRightTypeImage = transform.GetChild(4).GetComponent<Image>();

			_pointsText = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();

		}
		public void UpdateCardInformation()
		{
			_cardImage.sprite = _cardInformation.GetCardSprite();
			_cardColorImage.sprite = _cardInformation.GetCardColorSprite();
			_bonusColorImage = _cardInformation.GetCardBonusColorSprite();

			switch (_cardInformation.GetBonusType())
			{
				case CardBonusType.Left:
					_cardLeftTypeImage.sprite = _bonusColorImage;
					break;
				case CardBonusType.Center:
					_cardCenterTypeImage.sprite = _bonusColorImage;
					break;
				case CardBonusType.Right:
					_cardRightTypeImage.sprite = _bonusColorImage;
					break;
				case CardBonusType.LeftAndRight:

					break;
			}

			UpdatePointsInformation();
		}

		public void UpdatePointsInformation()
		{
			_pointsText.text = _cardInformation.GetPoints().ToString();
		}
	}
}