using UnityEngine;
using Game_Logic.CardLogic;

namespace Game_Logic.Client
{

    [System.Serializable]
    public class Client
    {


        [SerializeField] private CardColor _mainReq;
        [SerializeField] private CardColor _addReq;

        public CardColor GetMain() => _mainReq;
        public CardColor GetAdd() => _addReq;
    }
}