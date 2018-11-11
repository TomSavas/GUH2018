using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public GameObject Player;
	public GameObject Score;
	public EnemySpawner EnemySpawner;
	public SpawnPickUps PickupSpawner;
	public CameraFollower CameraMovement;
	public ScoringSystem Scoring;

	public GameObject Title;
	public GameObject PlayButton;
	public GameObject ExitButton;

	private bool _isInGame;
	
	public void StartGame()
	{
		_isInGame = true;
		Player.SetActive(true);
		Score.SetActive(true);
		EnemySpawner.Enabled = true;
		PickupSpawner.Enabled = true;
		CameraMovement.enabled = true;
		Scoring.Playing = true;
		Scoring.ResetScore();
		
		//Hide menu UI
		Title.SetActive(false);
		PlayButton.SetActive(false);
		ExitButton.SetActive(false);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
