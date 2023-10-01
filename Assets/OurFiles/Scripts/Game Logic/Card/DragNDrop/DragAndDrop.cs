using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	[Header("����� ���������")]
	[SerializeField] private ElementsBufer _elementsBufer;

	private Canvas _mainCanvas;
	private Transform _parentForRetun;
	
	// ���������� ����� ��� ������� State
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
						hit.transform.GetComponent<TableLogic>().ProcessTableLogic(transform);
						_onTable = true;
						break;
				}
			}
			else
			{
				transform.parent = _parentForRetun;
				transform.position = _parentForRetun.position;
				GetComponent<BoxCollider>().enabled = true;
			}
		}
	}
}