using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreTextDisplayer : MonoBehaviour
{
	public ScoringSystem ScoringSystem;
	public String ScorePrefix;

	private TextMeshProUGUI _textMesh;
	
	private void Start ()
	{
		_textMesh = GetComponent<TextMeshProUGUI>();
	}
	
	private void Update ()
	{
		_textMesh.text = ScorePrefix + ScoringSystem.Score;
	}
}
