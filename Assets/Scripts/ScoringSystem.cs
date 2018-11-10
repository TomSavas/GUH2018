using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
	public float Score { get; private set; }
	public bool Playing = false;

	private float _highScore;

	private void Update () 
	{
		if (Playing)
		{
			Score += GetScoreIncrement();
			_highScore = Mathf.Max(Score, _highScore);
		}
	}

	private float GetScoreIncrement()
	{
		return 1f;
	}

	public void ResetScore()
	{
		Score = 0;
	}
}
