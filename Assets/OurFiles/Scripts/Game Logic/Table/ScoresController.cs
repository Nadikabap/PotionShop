using Game_Logic.General;
using System.Collections;
using UnityEngine;

namespace Game_Logic.Table
{
	public class ScoresController : MonoBehaviour
	{
		[SerializeField] private ElementsBufer _elementsBufer;

		private int _scores;

		private void Start()
		{
			_scores = 0;
			UpdateScoresText();
		}

		public void ScoresModify(int value)
		{
			_scores += value;
		}

		public void UpdateScoresText()
		{
			_elementsBufer.GetScoresText().text = "Scores: " + _scores;
		}
	}
}