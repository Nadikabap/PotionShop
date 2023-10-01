using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableLogic : MonoBehaviour
{
    [SerializeField] private ElementsBufer _elementsBufer;

    public void ProcessTableLogic(Transform card)
    {
        PutReceivedCard(card);
		// ���������� ����� ��� ������� ������ ������ ������ CheckFullTable()
		if (CheckOnFullTable())
        {
            ClearTable();
        }
    }
	private void PutReceivedCard(Transform card)
    {
        if (GetComponent<TablePositions>().IsThereFreePosition())
        {
            Transform newTransform = GetComponent<TablePositions>().GetFreePosition();

            card.transform.parent = newTransform;
            card.transform.position = newTransform.position;

            GetComponent<TablePositions>().AddCardInList(card.gameObject);
        }

        // ����� ����������, ����� ����� �����, � �� ����� �����
        ModifyPoint(int.Parse(card.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text));
    }

    private bool CheckOnFullTable()
    {
        if (!GetComponent<TablePositions>().IsThereFreePosition())
        {
            if (_elementsBufer.GetPointsController().GetPoints() >= 0)
            {
                _elementsBufer.GetScoresController().ScoresModify(_elementsBufer.GetPointsController().GetPoints());
                _elementsBufer.GetScoresController().UpdateScoresText();
                _elementsBufer.GetPointsController().ResetPoints();
                _elementsBufer.GetPointsController().UpdatePointsText();
            }
            else
            {
                _elementsBufer._textForTests.text = "�� ��������, �������� ����";
            }
            return true;
        }
        return false;
    }

	private void ModifyPoint(int value)
	{
        _elementsBufer.GetPointsController().ModifyPoints(value);
        _elementsBufer.GetPointsController().UpdatePointsText();
	}

    private void ClearTable()
    {
        GetComponent<TablePositions>().ClearCardsInList();
    }
}