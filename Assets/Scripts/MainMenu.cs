using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class MainMenu : MonoBehaviour {

	public GUISkin racingGUISkin;
	public Vector2 buttonStartLocation;
	public Vector2 buttonExitLocation;
	public _GUIClasses.Location center = new _GUIClasses.Location();
	
	// Update is called once per frame
	void Update () {
		center.updateLocation();
	}
	
	void OnGUI(){
		GUI.skin = racingGUISkin;
		GUI.depth = -1;

		if(GUI.Button(new Rect(center.offset.x + buttonStartLocation.x, center.offset.y +buttonStartLocation.y, 140, 50), "START")){
			Application.LoadLevel("volume3");	
		}
		
		if(GUI.Button(new Rect(center.offset.x + buttonExitLocation.x, center.offset.y +buttonExitLocation.y, 140, 50), "EXIT")){
			Application.Quit();	
		}
	}

}
