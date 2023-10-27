using UnityEngine;
using UnityEngine.UIElements;

namespace Game_Logic.CardLogic
{
    [System.Serializable]
    public class Card
    {
        public enum CardState
        {
            InDeck,
            OnTable,
            BeforeCreate
        }

        [SerializeField] private Image _image;
        [SerializeField] private int _point;
        private CardState _state;
        //public CardColor _color;
        [SerializeField] private CardColor _color;
        [SerializeField] private CardBonusType _bonus;
        [SerializeField] private BonusColor _bonusColor;

        public void SetState(CardState state) => _state = state;
        public void SetColor(CardColor color) => _color = color;
        public void SetBonus(CardBonusType bonus) => _bonus = bonus;
        public void SetBonusColor(BonusColor bonusColor) => _bonusColor = bonusColor;
        public void SetPointMinus() => _point *= -1;

        public CardColor GetColor() => _color;
        public CardBonusType GetBonusType() => _bonus;
        public BonusColor GetBonusColor() => _bonusColor;

        public int GetPoint() => _point;
    }
}