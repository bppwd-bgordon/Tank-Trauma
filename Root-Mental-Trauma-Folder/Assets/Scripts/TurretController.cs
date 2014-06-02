using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

	public Transform pivot;
	public Transform shotOrigin;
	public float rotateSpeed;

	void Update()
	{ 
		if (!pivot || !shotOrigin) return; //Bulletproofing 
	}
}
