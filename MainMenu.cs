using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public bool quit = false; 
	public Texture2D emptyProgressBar
	public Texture2D fullProgressBar;
	public Texture2D colorTexture;
	private AsyncOperation async = null; 

	private IEnumerator LoadALevel(string levelName) {
		//print ("Loading...");
		async = SceneManager.LoadSceneAsync(levelName);
		yield return async;
	}

	void OnMouseEnter()
	{

		GetComponent<Renderer>().material.color = Color.gray;

	}

	void OnMouseExit()
	{

		GetComponent<Renderer>().material.color = Color.white;

	}

	void OnMouseUp()
	{

		if (quit == true)
		{
			Application.Quit();	
		}
		else
		{
			StartCoroutine (LoadALevel ("Demo_1"));
		}

	}

	void Update()
	{

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

	}

	void OnGUI ()
	{
		if (async == null) {
			Cursor.visible = true;
		}

		if (async != null) {
			GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), colorTexture, ScaleMode.StretchToFill, true);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 130, Screen.height - 100, 260, 50), emptyProgressBar);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 130, Screen.height - 100, 260 * async.progress, 50), fullProgressBar);
		}
	}
}
