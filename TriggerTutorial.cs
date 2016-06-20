using UnityEngine;
using System.Collections;

public class TriggerTutorial : MonoBehaviour {
	
	private bool isEnable;
	private bool show;
	public bool ReqSuite = false;
	private bool OnSuite;
	private GameObject player;
	public string Button = "E";
	private KeyCode key;
	public int x = 115;
	public int y = 100;
	public int width = 240;
	public int height = 40;
	public string text = "Нажмите 'E' чтобы открыть дверь";

	void Start ()
	{
		isEnable = true;
		show = false;
		player = GameObject.FindGameObjectWithTag("Player");
		key = (KeyCode)System.Enum.Parse (typeof(KeyCode), Button);
	}

	void Update()
	{
		if (Input.GetKeyDown (key) && show) {
			show = false;
		}

		if (ReqSuite) {
			OnSuite = player.GetComponent<Database> ().OnSuite;
		} else {
			OnSuite = true;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player" && isEnable && OnSuite)
		{
			OnGUI();
			isEnable = false;
			show = true;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if(other.tag == "Player" && OnSuite)
		{
			show = false;
			GetComponent<TriggerTutorial> ().enabled = false;
		}
	}

	void OnGUI()
	{
		if(show)
		{
			GUI.Box(new Rect(Screen.width/2 - x, Screen.height - y, width, height), text);
		}
	}
}
