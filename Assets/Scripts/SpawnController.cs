using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public Transform spawnPoint;
	public Vector3 currentTrackPosition;

	public bool activeRespawnTimer = false;
	public float respawnTimer = 1.0f;
	public float resetRespawnTimer = 1.0f;

	// Use this for initialization
	void Start () {
		if(spawnPoint != null){
			transform.position = spawnPoint.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		DamageController damageController = gameObject.GetComponent<DamageController>();
		EnemyMovement enemyMovement = gameObject.GetComponent<EnemyMovement>();
		PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();

		if(activeRespawnTimer){
			respawnTimer -= Time.deltaTime;
		}

		if(respawnTimer <= 0.0f){
			transform.position = currentTrackPosition;
			respawnTimer = resetRespawnTimer;
			activeRespawnTimer = false;

			damageController.health = 4;

			if(gameObject.tag == "Enemy"){
				enemyMovement.aiSpeed = enemyMovement.resetAISpeed;
				enemyMovement.aiTurnSpeed = enemyMovement.resetAITurnSpeed;
			}

			if(gameObject.tag == "Player"){
				playerMovement.speed = playerMovement.resetSpeed;
				playerMovement.turnSpeed = playerMovement.resetTurnSpeed;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "CheckPoint"){
			currentTrackPosition = transform.position;
		}
		if(other.tag == "DeadZone"){
			activeRespawnTimer = true;
		}
	}

}
