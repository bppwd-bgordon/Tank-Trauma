using UnityEngine;
using System.Collections;

public class PlayerMovementControl : MonoBehaviour 
{

	public float moveSpeed;
	public float turnSpeed;
	public Vector3 COM;
	public WheelCollider FrontLeftWheel;
	public WheelCollider FrontRightWheel;
	public WheelCollider BackLeftWheel;
	public WheelCollider BackRightWheel;

	void Start()
	{
		rigidbody.centerOfMass += COM;
	}

	void FixedUpdate() 
	{
		if (Input.GetAxis ("Horizontal") > 0) {
			FrontLeftWheel.motorTorque = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			BackLeftWheel.motorTorque = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			FrontRightWheel.motorTorque = -Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			BackRightWheel.motorTorque = -Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		} 
		else if (Input.GetAxis ("Horizontal") < 0) 
		{
			FrontLeftWheel.motorTorque = -Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			BackLeftWheel.motorTorque = -Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			FrontRightWheel.motorTorque = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			BackRightWheel.motorTorque = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		}

		if (Input.GetAxis ("Vertical") != 0) 
		{
			FrontLeftWheel.motorTorque = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			BackLeftWheel.motorTorque = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			FrontRightWheel.motorTorque = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			BackRightWheel.motorTorque = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
		}
	}
}

