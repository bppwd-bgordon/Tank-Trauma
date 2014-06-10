using UnityEngine;
using System.Collections;

public class Map_PlayerPosition : MonoBehaviour {

	void Start ()
	{
		
		float depth = gameObject.transform.lossyScale.z;
		float width = gameObject.transform.lossyScale.x;
		float height = gameObject.transform.lossyScale.y;
		Vector3 lowerLeftPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x - width/2, gameObject.transform.position.y - height/2, gameObject.transform.position.z - depth/2 ) );
		Vector3 upperRightPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x + width/2, gameObject.transform.position.y + height/2, gameObject.transform.position.z - depth/2 ) );
		float xPixelDistance = Mathf.Abs( lowerLeftPoint.x - upperRightPoint.x );
		float yPixelDistance = Mathf.Abs ( lowerLeftPoint.y - upperRightPoint.y );
		print( "This is the X pixel distance: " + xPixelDistance + " This is the Y pixel distance: " + yPixelDistance );
	}
}
