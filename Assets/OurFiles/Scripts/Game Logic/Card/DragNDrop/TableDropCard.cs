using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_Logic.CardLogic.DragNDrop
{
	public class TableDropCard : MonoBehaviour, IDropHandler
	{
		public void OnDrop(PointerEventData eventData)
		{
			var otherItemTransform = eventData.pointerDrag.transform;
			otherItemTransform.SetParent(transform);
		}
	}
}