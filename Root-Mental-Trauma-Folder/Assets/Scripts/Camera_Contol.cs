using UnityEngine;
using System.Collections;

public class Camera_Contol : MonoBehaviour {

	public Transform player1;
	public Transform player2;
	public Transform player3;
	public Transform player4;

	public float height = 11f;
	public float minZoom = 40f; // Not yet used
	public float maxZoom = 150f; // Not yet used

	public float zoomBuffer = 10f; // The extra distance put around the players
	public float zoomSpeed = 2;

	private Vector3 wantedPosition;

	private float lowX;
	private float highX;
	private float totalX;

	private float lowZ;

	private Vector3 lowXPos;
	private Vector3 highXPos;
	private Vector3 screenOrigin;

	void Start()
	{
		//Debug.Log (Camera.main.pixelWidth);
	}

	void Update()
	{
		// Determine which players have the highest and lowest X 
		lowX = Mathf.Min(player1.position.x, player2.position.x, player3.position.x, player4.position.x);
		highX = Mathf.Max(player1.position.x, player2.position.x, player3.position.x, player4.position.x);

		// Determine which player has the lowest Z 
		lowZ = Mathf.Min(player1.position.z, player2.position.z, player3.position.z, player4.position.z);

		// Determine difference in highX and lowX
		totalX = Mathf.Abs(lowX) + Mathf.Abs(highX);

		// Determine screenPos of lowX and highX
		lowXPos = camera.WorldToScreenPoint(new Vector3(lowX,0,0));

		// Set up screen origin point relative to world point
		screenOrigin = camera.WorldToScreenPoint(new Vector3(0,0,0));

		// If the player farthest to the left leaves the screen, adjust the camera's z to compensate
		if(!(lowXPos.x < screenOrigin.x)) Debug.Log("A player is out of view!");

		// Determine wanted position:
		// X: totalX is divided by two to put camera in center of players
		// Y: The height of the camera as specified in the inspector
		// Z: How far back the camera should be to fix all players, plus buffer distance
		wantedPosition = new Vector3(totalX / 2, height, lowZ + zoomBuffer );
		
		// Set the camera's new position using lerp to smoothly transition
		transform.position = Vector3.Lerp (transform.position, wantedPosition, zoomSpeed * Time.deltaTime);
	}	
}