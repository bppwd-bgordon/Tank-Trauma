/*using UnityEngine;
using System.Collections;

public class pc_camera_setup : MonoBehaviour {

	public Transform player;
	public float defaultHeight = 11.92652f;
	public float defaultDistance = -9.068643f;
	public float smoothValue = 3f;
	public float maxZoomIn = 10f;
	public float maxZoomOut = 10f;

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		
	}
}*/

using UnityEngine;

public class pc_camera_setup : MonoBehaviour {

	public Transform lookAtTarget1;
	public Transform lookAtTarget2;
	public Transform lookAtTarget3;
	public Transform frameTarget;
	public float distance = 10.0f;
	public float height = 5.0f;
	public float damping = 2.0f;
	
	private Vector3 direction;
	private Vector3 wantedPosition;
	private Vector3 lookAtTarget;
	
	void FixedUpdate () {
		
		if (!frameTarget || !lookAtTarget1 || !lookAtTarget2 || !lookAtTarget3)
			return;
		lookAtTarget = lookAtTarget1.position + lookAtTarget2.position + lookAtTarget3.position;

		direction = (frameTarget.position - lookAtTarget);
		
		wantedPosition = frameTarget.position + (direction.normalized * distance);
		wantedPosition.y = wantedPosition.y + height;
		
		transform.position = Vector3.Lerp(transform.position, wantedPosition, damping * Time.deltaTime);
		
		transform.LookAt (lookAtTarget);
	}
	
}