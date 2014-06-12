using UnityEngine;
using System.Collections;

public class GUI_Setup : MonoBehaviour {

	public Texture2D healthFrame;
	public Texture2D healthBar;
	public Texture2D energyBar;

	public Rect framePosition;
	public Rect hpBarPosition;
	public Rect epBarPosition;

	public float hpHorDistance = 0.35f;
	public float hpVertDistance = 0.09f;
	public float hpBarWidth = 0.58f;
	public float hpBarHeight = 0.16f;

	public float epHorDistance = 0.35f;
	public float epVertDistance = 0.09f;
	public float epBarWidth = 0.58f;
	public float epBarHeight = 0.16f;

	void Start(){
		//Debug.Log (Screen.height + " X " + Screen.width);
	}

	void OnGUI(){
		drawFrame ();
		drawHpBar ();
		drawEpBar ();
	}

	void drawFrame(){
		GUI.DrawTexture (framePosition, healthFrame);
		framePosition.width = Screen.width * 0.526027397260274f;
		framePosition.height = Screen.height * 0.2005479452054795f;
	}

	void drawHpBar(){
		hpBarPosition.x = framePosition.x + framePosition.width * hpHorDistance;
		hpBarPosition.y = framePosition.y + framePosition.height * hpVertDistance;

		GUI.DrawTexture (hpBarPosition, healthBar);
		hpBarPosition.width = framePosition.width * hpBarWidth;
		hpBarPosition.height = framePosition.height * hpBarHeight;
	}

	void drawEpBar(){
		epBarPosition.x = framePosition.x + framePosition.width * epHorDistance;
		epBarPosition.y = framePosition.y + framePosition.height * epVertDistance;
		
		GUI.DrawTexture (epBarPosition, energyBar);
		epBarPosition.width = framePosition.width * epBarWidth;
		epBarPosition.height = framePosition.height * epBarHeight;
	}
}