using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_Logic.CardLogic.DragNDrop
{
	public class TestDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public void OnPointerEnter(PointerEventData eventData)
		{

			if (eventData.pointerDrag == null)
				return;

			TestDraggable d = eventData.pointerDrag.GetComponent<TestDraggable>();
			if (d != null)
			{
				d.placeHolderParent = this.transform;
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{

			if (eventData.pointerDrag == null)
				return;

			TestDraggable d = eventData.pointerDrag.GetComponent<TestDraggable>();
			if (d != null && d.placeHolderParent == this.transform)
			{
				d.placeHolderParent = d.parentToReturnTo;
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

			TestDraggable d = eventData.pointerDrag.GetComponent<TestDraggable>();
			if (d != null)
			{
				d.parentToReturnTo = this.transform;
			}
		}
	}
}