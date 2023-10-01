using Assets.OurFiles.Scripts.Game_Logic.Table;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementsBufer : MonoBehaviour
{
    [Header("��������� ����������")]
    [SerializeField] private Canvas _mainCanvas;

    [Header("������� �� ������ ��������")]
    [SerializeField] private PointsController _pointsController;
    [SerializeField] private ScoresController _scoresController;

    [Header("��������� ������")]
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private TextMeshProUGUI _scoresText;

    public TextMeshProUGUI _textForTests;

    public Canvas GetMainCanvas() => _mainCanvas;
    public PointsController GetPointsController() => _pointsController;
    public ScoresController GetScoresController() => _scoresController;
    public TextMeshProUGUI GetPointsText() => _pointsText;
    public TextMeshProUGUI GetScoresText() => _scoresText;
}
