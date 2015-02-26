using UnityEngine;
using System.Collections;

public class PlayerContoroller : MonoBehaviour {

	public float HorSpeed;
	public float VerSpeed;
	public float JumpPower;
	public int jumpCount = 0;		// ジャンプした回数
	public const int MAX_JUMP_COUNT = 2;

	// Apply a upwards force to the rigid body every frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal") * HorSpeed;
		float moveVertical = Input.GetAxis ("Vertical") * VerSpeed;

		if (jumpCount < MAX_JUMP_COUNT && Input.GetButtonDown("Jump")) {
			jumpCount++;
			this.rigidbody.velocity += Vector3.up * JumpPower;
//			rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
		}
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce (movement * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Ground") {
			jumpCount = 0; // ジャンプ回数初期化
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
		}
	}
}
