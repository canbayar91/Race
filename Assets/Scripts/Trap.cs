using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	public int damage = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy" || other.tag == "Player"){
			other.GetComponent<Collider>().SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

}
