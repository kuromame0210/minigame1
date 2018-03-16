using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube: MonoBehaviour {
	private float x, y, z,speed;
	private Vector3 pos;
	private bool clear = false;
	// Use this for initialization
	void Start () {
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
		speed = 1f;
	}
	
	// Update is called once per frame
	void Update () {

		//spaceキーでジャンプ
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump ();
		}

		//キー入力による移動
		move ();


		//shiftキーを押したとき減速
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			speed = 0.5f;
		}

		//shiftきーを離したとき元の速さ
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			speed = 1f;
		}

		//フィールドから落っこちた時の処置
		if (transform.position.y < -5f) {
			transform.position = new Vector3 (0, 0.5f, 0);
		}

		//クリアした後の処理
		if (Input.GetKeyDown (KeyCode.LeftControl) && clear) {
			transform.position = new Vector3 (0, 0.5f, 0);
		}
	}

	private void jump(){
		transform.Translate (0, 2, 0);
	}

	private void move(){
		transform.Translate (speed * Input.GetAxis ("Horizontal") * 0.1f, 0, speed * Input.GetAxis ("Vertical") * 0.1f);
	}

	//ゴールの判定
	void OnTriggerEnter(Collider other){
		if (other.tag == "clear") {
			print ("congratulation!" +
			"please push LeftControlKey!!");
			clear = true;
			
		}
	}
}
