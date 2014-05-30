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
	
	public Transform lookAtTarget;
	public Transform frameTarget;
	public float distance = 10.0f;
	public float height = 5.0f;
	public float damping = 2.0f;
	
	private Vector3 direction;
	private Vector3 wantedPosition;
	
	void FixedUpdate () {
		
		if (!lookAtTarget || !frameTarget)
			return;
		
		direction = (frameTarget.position - lookAtTarget.position);
		
		wantedPosition = frameTarget.position + (direction.normalized * distance);
		wantedPosition.y = wantedPosition.y + height;
		
		transform.position = Vector3.Lerp(transform.position, wantedPosition, damping * Time.deltaTime);
		
		transform.LookAt (lookAtTarget);
		
	}
	
}