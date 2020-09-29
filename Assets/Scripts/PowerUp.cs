using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public enum PowerType{
		Projectile = 0,
		Trap = 1,
		Boost = 2
	}
	
	public PowerType powerUpType;
	private GameObject playerGameObject;

	public float respawnTimer = 10.0f;
	public float resetRespawnTimer = 10.0f;
	public bool respawnTimerActive = false;

	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(respawnTimerActive){
			respawnTimer -= Time.deltaTime;
			if(respawnTimer <= 0.0f){
				respawnTimerActive = false;
				respawnTimer = resetRespawnTimer;
				gameObject.GetComponent<Collider>().enabled = true;
				gameObject.GetComponent<Renderer>().enabled = true;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		PlayerProperties playerProperties = playerGameObject.GetComponent<PlayerProperties>();
		if(other.tag == "Player" && playerProperties.canPickUp){
			Debug.Log("We have a power up");
			ApplyPowerUp(playerProperties);

			gameObject.GetComponent<Collider>().enabled = false;
			gameObject.GetComponent<Renderer>().enabled = false;
			respawnTimerActive = true;
		}
	}

	public int ApplyPowerUp(PlayerProperties playerStatus){
		switch(powerUpType){
		case PowerType.Projectile:
			if(playerStatus.playerState == PlayerProperties.PlayerState.CarNormal){
				Debug.Log("We have a projectile");
				playerStatus.playerState = PlayerProperties.PlayerState.CarProjectile;
				playerStatus.hasProjectile = true;
				playerStatus.changeState = true;
			}
			break;
		case PowerType.Trap:
			if(playerStatus.playerState == PlayerProperties.PlayerState.CarNormal){
				Debug.Log("We have a trap");
				playerStatus.playerState = PlayerProperties.PlayerState.CarTrap;
				playerStatus.hasTrap = true;
				playerStatus.changeState = true;
			}
			break;
		case PowerType.Boost:
			if(playerStatus.playerState == PlayerProperties.PlayerState.CarNormal){
				Debug.Log("We have a boost");
				playerStatus.playerState = PlayerProperties.PlayerState.CarBoost;
				playerStatus.hasBoost = true;
				playerStatus.changeState = true;
			}
			break;
		}
		return (int) powerUpType;
	}

}
