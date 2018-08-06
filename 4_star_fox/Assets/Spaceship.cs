using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Spaceship : MonoBehaviour {

	float xThrow;
	float yThrow;

	[SerializeField] float xSpeed = 4f;
	[SerializeField] float ySpeed = 4f;
	[SerializeField] float rotationPowerPosition = -5f;
	[SerializeField] float rotationPowerThrow = -15f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		rotate ();

		 
	}


	void rotate() {
		float x = transform.localPosition.y * rotationPowerPosition + yThrow * rotationPowerThrow;
		float y = transform.localPosition.x * rotationPowerPosition + xThrow*rotationPowerThrow;
		float z = transform.localPosition.x * rotationPowerPosition + xThrow * rotationPowerThrow;


		transform.localRotation = Quaternion.Euler (x, y, z);

	}

	void move() {
		
		xThrow = CrossPlatformInputManager.GetAxis ("Horizontal");

		float xOffsetThisFrame = xSpeed * xThrow * Time.deltaTime;

		float xRawPosition = transform.localPosition.x + xOffsetThisFrame;
		float xClampedPos = Mathf.Clamp (xRawPosition, -4.5f, 4.5f);

		yThrow = CrossPlatformInputManager.GetAxis ("Vertical");
		float yOffsetThisFrame = ySpeed * yThrow * Time.deltaTime;

		float yRawPosition = transform.localPosition.y + yOffsetThisFrame;
		float yClampedPos = Mathf.Clamp (yRawPosition, -3f, 3f);

		transform.localPosition = new Vector3 (xClampedPos, yClampedPos, transform.localPosition.z);

	}
}
