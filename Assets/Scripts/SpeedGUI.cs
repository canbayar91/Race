using UnityEngine;
using System.Collections;
[ExecuteInEditMode()]

public class SpeedGUI : MonoBehaviour {

	public GUISkin racingGUISkin;
	
	public int offsetX = 0;
	public int offsetY = 0;

	public int lapOffsetX = 0;
	public int lapOffsetY = 0;
	
	private float speed = 0.0f;
	private int lap = 0;
	
	private GameObject playerGameObject;
	
	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		PlayerMovement playerMovement = playerGameObject.GetComponent<PlayerMovement>();	
		speed = playerMovement.currentSpeed * 10;
		lap = CheckpointController.currentLap;
		
		GUI.skin = racingGUISkin;
		GUI.Label(new Rect(Screen.width / 2 + offsetX, Screen.height / 2 + offsetY, 1000, 100), speed.ToString("f0"));
		GUI.Label(new Rect(Screen.width / 2 + lapOffsetX, Screen.height / 2 + lapOffsetY, 1000, 100), lap.ToString("f0"));
	}
}
