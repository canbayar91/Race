using UnityEngine;
using System.Collections;

public class HealthGUI : MonoBehaviour 
{
	public Texture2D health_100;
	public Texture2D health_75;
	public Texture2D health_50;
	public Texture2D health_25;
	public Texture2D health_00;
	
	public int healthGUI = 4;
	private GameObject playerGameObject;
	
	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		DamageController damageController = playerGameObject.GetComponent<DamageController>();
		healthGUI = damageController.health;
		
		switch(healthGUI){
		case 4: 
			GetComponent<GUITexture>().texture = health_100;
			break;	
		case 3: 
			GetComponent<GUITexture>().texture = health_75;
			break;
		case 2: 
			GetComponent<GUITexture>().texture = health_50;
			break;
		case 1: 
			GetComponent<GUITexture>().texture = health_25;
			break;
		case 0: 
			GetComponent<GUITexture>().texture = health_00;
			break;
		}
	}
}
