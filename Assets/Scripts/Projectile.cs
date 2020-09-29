using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float lifeSpan = 3.0f;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		DestroyProjectile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Obstacle"){
			Destroy(gameObject);
		}

		if(other.tag == "Enemy" || other.tag == "Player"){
			other.GetComponent<Collider>().SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

	void DestroyProjectile(){
		Destroy(gameObject, lifeSpan);
	}

}
