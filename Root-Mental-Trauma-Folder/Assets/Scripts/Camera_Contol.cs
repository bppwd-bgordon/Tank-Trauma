using UnityEngine;
using System.Collections;

public class Camera_Contol : MonoBehaviour {

	public Transform player1;
	public Transform player2;
	public Transform player3;
	public Transform player4;

	public float height = 11f;
	public float minZoom = 40f;
	public float maxZoom = 150f;

	public float zoomBuffer = 10f; // The extra distance put around the players
	public float zoomSpeed = 2;

	private Vector3 wantedPosition;

	private float lowX;
	private float highX;
	private float totalX;

	private float lowZ;

	void Start()
	{
		//Debug.Log (Camera.main.pixelWidth);
	}

	void Update()
	{
		Debug.Log (Camera.main.pixelWidth);

		// Determine which players have the highest and lowest X 
		lowX = Mathf.Min(player1.position.x, player2.position.x, player3.position.x, player4.position.x);
		highX = Mathf.Max(player1.position.x, player2.position.x, player3.position.x, player4.position.x);

		// Determine which player has the lowest Z 
		lowZ = Mathf.Min(player1.position.z, player2.position.z, player3.position.z, player4.position.z);

		// Determine difference in highX and lowX
		totalX = Mathf.Abs(lowX) + Mathf.Abs(highX);

		// If a player leaves the field of view, move the camera back far enough to fit that player
		//if ()

		// Determine wanted position:
		// X: totalX is divided by two to put camera in center of players
		// Y: The height of the camera as specified in the inspector
		// Z: How far back the camera should be to fix all players, plus buffer distance
		wantedPosition = new Vector3(totalX / 2, height, lowZ + zoomBuffer);
		
		// Set the camera's new position using lerp to smoothly transition
		transform.position = Vector3.Lerp (transform.position, wantedPosition, zoomSpeed * Time.deltaTime);
	}	
}