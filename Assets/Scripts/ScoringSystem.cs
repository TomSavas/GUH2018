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
			Increment();
			_highScore = Mathf.Max(Score, _highScore);
		}
	}

	private float GetScoreIncrement()
	{
		return 1f;
	}

	public void Increment()
	{
			Score += GetScoreIncrement();
	}

	public void BigIncrement()
	{
		for(int i = 0; i < 10; i++)
			Increment();
	}
	
	public void ResetScore()
	{
		Score = 0;
	}
}
