using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_Logic.CardLogic.DragNDrop
{
	public class UISlot : MonoBehaviour, IDropHandler
	{
		public void OnDrop(PointerEventData eventData)
		{
			Debug.Log("EventData " + eventData);
			Transform otherItemTransform = eventData.pointerDrag.transform;
			Debug.Log("OtherItemTransfrom " + otherItemTransform);
			otherItemTransform.SetParent(transform);
			otherItemTransform.localPosition = Vector3.zero;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.CompareTag("Table"))
				{
					Debug.Log("Table");
				}
			}
		}
	}
}