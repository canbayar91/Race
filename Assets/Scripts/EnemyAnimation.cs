using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour 
{
	public int columns = 8;
	public int rows = 8;

	public int currentFrame = 1;
	public int currentAnim = 0;
	public float animTime = 0.0f;
	public float fps = 10.0f;
	
	public bool explode = false;
	public bool spinning = false;
	private bool turning = false;
	
	private Vector2 framePosition;
	private Vector2 frameSize;
	private Vector2 frameOffset;
	private int i;
	
	private float carVelocity;
	private Vector3 currentWaypoint;

	private int idle = 41;
	private int driveMin = 27;
	private int driveMax = 28;
	private int driveLeftMin = 29;
	private int driveLeftMax = 30;
	private int driveRightMin = 31;
	private int driveRightMax = 32;
	private int spin = 33;
	private int explosionMin = 34;
	private int explosionMax = 40;

	private int animIdle = 0;
	private int animDrive = 1;
	private int animDriveLeft = 2;
	private int animDriveRight = 3;
	private int animSpin = 4;
	private int animExplosion = 5;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleAnimation();
		
	}
	
	void HandleAnimation(){
		FindAnimation();
		PlayAnimation();	
	}
	
	float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector){
		if(toVector == Vector3.zero){
			return 0.0f;	
		}
		
		float angle = Vector3.Angle(fromVector, toVector);
		Vector3 normal = Vector3.Cross(fromVector, toVector);
		angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
		angle *= Mathf.Deg2Rad;
		return angle;		
	}
	
	void FindAnimation(){
		float angle;
		
		EnemyMovement enemyMovement = transform.parent.GetComponent<EnemyMovement>();
		carVelocity = enemyMovement.currentSpeed;
		currentWaypoint = enemyMovement.currentWaypointPosition;
		angle = FindAngle(transform.forward, currentWaypoint - transform.parent.position, transform.up);
		
		if(carVelocity > 0.1f){
			currentAnim	= animDrive;
			if(turning){
				if(angle < 0.0f){
					currentAnim = animDriveLeft;	
				}
			
				if(angle > 0.0f){
					currentAnim = animDriveRight;	
				}
			}
			
		}
		if(carVelocity < 0.1f){
			currentAnim = animIdle;	
		}
		
		if(explode){
			currentAnim = animExplosion;	
		}
			
		if(spinning){
			currentAnim = animSpin;	
		}
	}
	
	void PlayAnimation(){
		animTime -= Time.deltaTime;
		if(animTime <= 0){
			currentFrame += 1;
			animTime += 1.0f / fps;
		}

		if(currentAnim == animExplosion){
			currentFrame = Mathf.Clamp(currentFrame, explosionMin, explosionMax + 1);
			if(currentFrame > explosionMax){
				explode = false;	
			}
		}

		if(currentAnim == animSpin){
			currentFrame = Mathf.Clamp(currentFrame, spin, spin);
		}

		if(currentAnim == animIdle){
			currentFrame = Mathf.Clamp(currentFrame, idle, idle);	
		}
		
		if(currentAnim == animDrive){
			currentFrame = Mathf.Clamp(currentFrame, driveMin, driveMax + 1);
			if(currentFrame > driveMax){
				currentFrame = driveMin;	
			}
		}
		if(currentAnim == animDriveLeft){
			currentFrame = Mathf.Clamp(currentFrame, driveLeftMin, driveLeftMax + 1);
			if(currentFrame > driveLeftMax){
				currentFrame = driveLeftMin;	
			}
		}
		if(currentAnim == animDriveRight){
			currentFrame = Mathf.Clamp(currentFrame, driveRightMin, driveRightMax + 1);
			if(currentFrame > driveRightMax){
				currentFrame = driveRightMin;	
			}
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
	
	void OnTriggerStay(Collider other){
		if(other.tag == "Turn"){
			turning = true;	
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag == "Turn"){
			turning = false;	
		}
	}
}
