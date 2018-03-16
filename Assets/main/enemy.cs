using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	float c;
	bool turn = true;
	[SerializeField] private float speed = 1f;

	// Use this for initialization
	void Start () {
		c = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//eneemyの移動制御
		if ((-3f <= c && c <= 3f) && turn) {
			move_right ();
		} else if ((-3f <= c && c <= 3f) && !turn) {
			move_left ();
		}
		if (c > 2.5f) {
			turn = false;
		}
		if (c < -2.5f) {
			turn = true;
		}

	}

	void move_right(){
		c += Time.deltaTime;
		transform.Translate (speed * Time.deltaTime, 0, 0);
	}

	void move_left(){
		c -= Time.deltaTime;
		transform.Translate (-1f * speed * Time.deltaTime, 0, 0);
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			other.transform.position = new Vector3 (0, 0.5f, 0);
		}
	}
}
