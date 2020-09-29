using UnityEngine;
using System.Collections;

public class PowerUpGUI : MonoBehaviour {

	public Texture2D powerUpProjectile;
	public Texture2D powerUpTrap;
	public Texture2D powerUpBoost;
	public Texture2D powerUpNone;
	
	private GameObject playerGameObject;
	
	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerProperties playerProperties = playerGameObject.GetComponent<PlayerProperties>();
		
		if(playerProperties.hasProjectile){
			GetComponent<GUITexture>().texture = powerUpProjectile;	
		} else if(playerProperties.hasTrap){
			GetComponent<GUITexture>().texture = powerUpTrap;	
		} else if(playerProperties.hasBoost){
			GetComponent<GUITexture>().texture = powerUpBoost;	
		}
		
		if(playerProperties.canPickUp)
		{
			GetComponent<GUITexture>().texture = powerUpNone;	
		}
	}
}
