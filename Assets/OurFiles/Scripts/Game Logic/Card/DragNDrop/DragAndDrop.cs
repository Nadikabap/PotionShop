using Game_Logic.Deck;
using Game_Logic.General;
using Game_Logic.Table;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_Logic.CardLogic.DragNDrop
{
	public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
	{
		[Header("Буфер элементов")]
		[SerializeField] private ElementsBufer _elementsBufer;

		private Canvas _mainCanvas;
		private Transform _parentForRetun;

		// Переделать потом под паттерн State
		private bool _onTable;

		private void Start()
		{
			_onTable = false;
			_elementsBufer = FindObjectOfType<ElementsBufer>();
			_mainCanvas = _elementsBufer.GetMainCanvas();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (!_onTable)
			{
				_parentForRetun = transform.parent;
				transform.parent = _mainCanvas.transform;
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!_onTable)
			{
				GetComponent<RectTransform>().anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (!_onTable)
			{
				GetComponent<BoxCollider>().enabled = false;

				RaycastHit hit;
				Camera mainCamera = Camera.main;

				Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(ray, out hit);

				if (hit.collider != null)
				{
					switch (hit.collider.tag)
					{
						case "Table":
							_parentForRetun.GetComponent<TopCard>().FlipCard();
							hit.transform.GetComponent<TableLogic>().ProcessTableLogic(transform, Input.mousePosition.x);
							_onTable = true;
							break;
						default:
							ReturnOnBackPosition();
							break;
					}
				}
				else
				{
					ReturnOnBackPosition();
				}
			}
		}

		private void ReturnOnBackPosition()
		{
			transform.parent = _parentForRetun;
			transform.position = _parentForRetun.position;
			GetComponent<BoxCollider>().enabled = true;
		}
	}
}