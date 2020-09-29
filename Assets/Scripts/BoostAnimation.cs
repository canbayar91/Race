using UnityEngine;
using System.Collections;

public class BoostAnimation : MonoBehaviour 
{
	public int columns = 8;
	public int rows = 8;
	
	// Animation control variables
	public int currentFrame = 1;
	public int currentAnim = 0;
	public float animTime = 0.0f;
	public float fps = 10.0f;
	
	private Vector2 framePosition;
	private Vector2 frameSize;
	private Vector2 frameOffset;
	private int i;
	
	// Animation frames
	private int boostMin = 42;
	private int boostMax = 45;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayAnimation();
	}
	
	void PlayAnimation(){
		animTime -= Time.deltaTime;
		if(animTime <= 0){
			currentFrame += 1;
			animTime += 1.0f / fps;
		}

		currentFrame = Mathf.Clamp(currentFrame, boostMin, boostMax + 1);
		if(currentFrame > boostMax){
			currentFrame = boostMin;	
		}
		
		framePosition.y = 1;
		for(i = currentFrame; i > columns; i -= rows){
			framePosition.y += 1;	
		}
		framePosition.x = i - 1; 
		
		frameSize = new Vector2(1.0f / columns, 1.0f / rows);
		frameOffset = new Vector2(framePosition.x / columns, 1.0f - (framePosition.y / rows));
		
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", frameSize);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", frameOffset);	
	}
}
