using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour 
{
	public float raceStartTimer	= 0.0f;
	public float resetRaceStartTimer = 0.0f;
	
	public int totalLaps = 3;
	
	public GameObject playerCar;
	public GameObject enemyCar;
	
	// Use this for initialization
	void Start () {
		resetRaceStartTimer = raceStartTimer;
		playerCar = GameObject.FindGameObjectWithTag("Player");
		enemyCar = GameObject.FindGameObjectWithTag("Enemy");
		PlayerMovement playerMovement = playerCar.GetComponent<PlayerMovement>();
		playerMovement.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement playerMovement = playerCar.GetComponent<PlayerMovement>();
		
		raceStartTimer -= Time.deltaTime;
		if(raceStartTimer <= 0.0f){
			playerMovement.enabled = true;
			EnemyMovement.raceStarted = true;
			raceStartTimer = 0.0f;
		}
		
		if(CheckpointController.currentLap == totalLaps + 1){
			EnemyMovement.raceStarted = false;
			playerMovement.speed = 0.0f;
			playerMovement.reverseSpeed = 0.0f;
			playerMovement.turnSpeed = 0.0f;

			Application.LoadLevel("MainMenu");
		}
	}
}
