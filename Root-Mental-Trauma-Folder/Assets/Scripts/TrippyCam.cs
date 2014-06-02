using UnityEngine;
using System.Collections;

public class TrippyCam : MonoBehaviour {

	void FixedUpdate(){
		//If the camera does not have players attached, break the script gracefully
//		if (!targetPlayer || !otherPlayer1 || !otherPlayer2 || !otherPlayer3) return;
	
		//If the camera cannot see a player, increase the FOV (smoothly)
//		if (!targetPlayer.renderer.isVisible || !otherPlayer1.renderer.isVisible || !otherPlayer2.renderer.isVisible || !otherPlayer3.renderer.isVisible) {
//			distance += zoomSpeed * Time.deltaTime;
//		}

		//Else, if the camera can see all players, decrease the FOV (smoothly)		
//		else if (targetPlayer.renderer.isVisible && otherPlayer1.renderer.isVisible && otherPlayer2.renderer.isVisible && otherPlayer3.renderer.isVisible) {
//			distance -= zoomSpeed * Time.deltaTime;
//		}

		//Clamp the camera's max and min FOV before zooming
//		Mathf.Clamp (distance, minDistance, maxDistance);
	}
}
