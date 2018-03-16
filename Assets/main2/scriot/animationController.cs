using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour {
	Animation anim;
	float samurai_ypos;
	float timecount = 0;
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		timecount += Time.deltaTime;

		//animation
		animationctr ();

	}

	//animation
	void animationctr(){
		//jump
		jumpAnim();

		//idle	

		idleAnim();;

		//attack
		attackanim ();
	}

	//implement attack and run
	void attackanim(){
		if (Input.GetKey (KeyCode.X)) {
			anim.Play ("Attack");
		}
	}
	//implement idle and lookLotation
	void idleAnim(){		

		Vector3 beforePos = transform.position;

		//移動
		transform.Translate (Input.GetAxis ("Horizontal") * 0.1f, samurai_ypos, Input.GetAxis ("Vertical") * 0.1f);

		Vector3 afterPos = transform.position;

		//run or
		//idle
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.Play ("Run");	
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.UpArrow)) {
				anim.Play ("idle");
		}
		if (rigidbody.velocity.magnitude > 0.01f) {			
				transform.rotation = Quaternion.LookRotation (afterPos - beforePos);
		}
	}
	//implement jump
	void jumpAnim(){

		//jump
		if (Input.GetKeyDown (KeyCode.Z) && timecount >= 1) {
			anim.Play ("Jump");
			transform.Translate (0, 1.2f, 0);
			timecount = 0;
		}			
	}

}