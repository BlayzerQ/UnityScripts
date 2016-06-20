using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Paper : MonoBehaviour {
	
	public HandPaper Papers;
	public Texture2D PaperZ;
	public bool PaperV = true;
	private GameObject player;
	public string TextLabel1;
	public string TextLabel2;
	public string TextLabel3;
	public string TextLabel4;
	public string TextLabel5;
	public string TextLabel6;
	public string TextLabel7;
	public string TextLabel8;
	public string TextLabel9;
	public string TextLabel10;
	public string TextLabel11;
	public string TextLabel12;
	public GUIStyle StyleText;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update ()
	{
		if (Papers.cursorenter == true && Input.GetKeyDown ("e") && player.GetComponent<FirstPersonController> ().OnSuite) {
			PaperV = !PaperV;
			player.GetComponent<CharacterController>().enabled = true;
			Papers.showgui = false;
		}
	}

	void OnGUI()
	{
		if (!PaperV) 
		{
			//Time.timeScale = 0;
			player.GetComponent<CharacterController>().enabled = false;
			Papers.showgui = true;
			GUI.DrawTexture (new Rect (Screen.width / 2 - 320, Screen.height / 2 - 245, 650, 445), PaperZ);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 - 200, 450, 545), TextLabel1, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 - 180, 450, 545), TextLabel2, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 - 160, 450, 545), TextLabel3, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 - 140, 450, 545), TextLabel4, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 - 120, 450, 545), TextLabel5, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 - 100, 450, 545), TextLabel6, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 - 80, 450, 545), TextLabel7, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 + 80, 450, 545), TextLabel8, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 + 100, 450, 545), TextLabel9, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 + 120, 450, 545), TextLabel10, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 + 140, 450, 545), TextLabel11, StyleText);
			GUI.Label (new Rect (Screen.width / 2 - 260, Screen.height / 2 + 160, 450, 545), TextLabel12, StyleText);
              
		}else{
		    PaperV = PaperV;
			//Time.timeScale = 1;
        }
	}
}