using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour 
{
	public int health = 4;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ApplyDamage(int damage){
		SpawnController spawnController = GetComponent<SpawnController>();
		SpriteAnimation spriteAnimation = GetComponentInChildren<SpriteAnimation>();
		PlayerMovement playerMovement = GetComponent<PlayerMovement>();

		EnemyAnimation enemyAnimation = GetComponentInChildren<EnemyAnimation>();
		EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

		if(gameObject.tag == "Player"){
			health -= damage;
			
			if(health == 0){
				spawnController.activeRespawnTimer = true;
				spriteAnimation.explode = true;
				playerMovement.speed = 0.0f;
				playerMovement.turnSpeed = 0.0f;
			}
		}

		if(gameObject.tag == "Enemy"){
			health -= damage;
			
			if(health == 0){
				spawnController.activeRespawnTimer = true;
				enemyAnimation.explode = true;
				enemyMovement.aiSpeed = 0.0f;
				enemyMovement.aiTurnSpeed = 0.0f;
			}
		}
	}

}
