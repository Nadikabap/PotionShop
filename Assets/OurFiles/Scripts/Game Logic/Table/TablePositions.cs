using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Table
{
    public class TablePositions : MonoBehaviour
    {
        [SerializeField] private List<Transform> _positions;
        [SerializeField] private List<GameObject> _cards;

        private int _indexFreePosition;

        public Transform GetFreePosition()
        {
            _positions[_indexFreePosition].GetComponent<PositionData>().SetFreeStatus(false);
            return _positions[_indexFreePosition];
        }
        public bool IsThereFreePosition()
        {
            for (int i = 0; i < _positions.Count; i++)
            {
                if (_positions[i].GetComponent<PositionData>().GetFreeStatus())
                {
                    _indexFreePosition = i;
                    return true;
                }
            }
            return false;
        }

        public void AddCardInList(GameObject card)
        {
            _cards.Add(card);
        }

        public void ClearCardsInList()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                Destroy(_cards[i]);
                _positions[i].GetComponent<PositionData>().SetFreeStatus(true);
            }
            StartCoroutine(DelayClear());
        }

        private IEnumerator DelayClear()
        {
            yield return new WaitForSeconds(0.3f);
            _cards.Clear();
        }

        public int CurrentListCount()
        {
            return _cards.Count;
        }

        public List<Transform> GetPositions() => _positions;
    }
}