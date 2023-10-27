using Game_Logic.General;
using System.Collections;
using UnityEngine;

namespace Game_Logic.Table
{
	public class PointsController : MonoBehaviour
	{
		[SerializeField] private ElementsBufer _elementsBufer;
		private int _points;

		private void Start()
		{
			ResetPoints();
			UpdatePointsText();
		}
		public void ResetPoints()
		{
			_points = 0;
		}

		public void ModifyPoints(int value)
		{
			_points += value;
		}

		public void UpdatePointsText()
		{
			_elementsBufer.GetPointsText().text = _points.ToString();
		}

		public int GetPoints()
		{
			return _points;
		}
	}
}