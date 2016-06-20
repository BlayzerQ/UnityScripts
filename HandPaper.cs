using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class HandPaper : MonoBehaviour {
	public float MaxDistance = 1.5f;
	public Texture2D CursorTexture;
	public bool cursorenter;
	public bool cursor;
	public Paper PaperVR;
	private GameObject player;
	public bool showgui;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		showgui = false;
	}

	void Update ()
	{
		//if(cursor == true)
		//{
		if(Vector3.Distance(transform.position, player.transform.position) < MaxDistance && player.GetComponent<FirstPersonController> ().OnSuite)
			{
				cursorenter = true;
			}
			else
			{
				cursorenter = false;
			}
		//}
		
	}

//	void OnMouseEnter()
//	{
//		cursor = true;
//	}

//	void OnMouseExit()
//	{
//		cursor = false;
//		cursorenter = false;
//	}
	
	void OnGUI ()
	{
		if(cursorenter && !showgui)
		{
			GUI.Box(new Rect(Screen.width/2 - 120, Screen.height - 100, 280, 40), "Нажмите 'E' чтобы дешифровать сообщение");
		}

	}
}
