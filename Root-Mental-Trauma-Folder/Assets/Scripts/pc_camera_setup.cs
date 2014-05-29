using UnityEngine;
using System.Collections;

public class pc_camera_setup : MonoBehaviour {
	
	private const float tilt = 41.28734f;
	private const float viewing_angle = 0f;

	// Use this for initialization
	void Start () {
		transform.rotation = new Quaternion(0,viewing_angle,tilt,360);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
