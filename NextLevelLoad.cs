using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelLoad : MonoBehaviour {

	private bool locklevel;

	void Start () 
	{
		locklevel = true;
	}

	void OnTriggerEnter () 
	{
		if (locklevel) 
		{
			SceneManager.LoadScene ("Main_Menu");
		}
	}
}
