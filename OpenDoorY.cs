using UnityEngine;
using System.Collections;

public class OpenDoorY : MonoBehaviour {

	private GameObject player;

	public AudioClip Sound;
	public int playerRange = 4;
	public int CloseTime = 3;
	public float Speed = 2.0f;
	public float UpLimit = -2f;
	public float DownLimit = -0f;
	public bool doorOpenned = false;
	public bool ReqSuite = false;
	private bool doorGo = false;
	private bool ShowReqSuite = false;
	private bool OnSuite;

	void Start () {
		
		doorOpenned = false;
		player = GameObject.FindGameObjectWithTag("Player");

	}

	void Update () {
		
		if (Vector3.Distance (transform.position, player.transform.position) < playerRange) {
				if (Input.GetKeyDown (KeyCode.E) && !doorGo) {
				if (OnSuite && !ShowReqSuite) {

					if (doorOpenned) {
						doorOpenned = false;
						if (player.GetComponent<AudioSource>().clip != Sound) {
							AudioSource.PlayClipAtPoint (Sound, transform.position);
						}
					} else {
						doorOpenned = true;
						if (player.GetComponent<AudioSource>().clip != Sound) {
							AudioSource.PlayClipAtPoint (Sound, transform.position);
						}
						StartCoroutine (WaitAndClose ());
					}

			    } else {
				    StartCoroutine(ShowAndClose());
			    }
				}

		}

		if (ReqSuite) {
			OnSuite = player.GetComponent<Database> ().OnSuite;
		} else {
			OnSuite = true;
		}
	}

	void FixedUpdate ()
	{
		if (doorOpenned) {
			if (transform.position.y <= UpLimit) {
				doorGo = true;
				transform.position = new Vector3 (transform.position.x, transform.position.y + Speed / 50, transform.position.z);
			}
			if (transform.position.y >= UpLimit) {
				doorGo = false;
			}
		} else 
			if (transform.position.y >= DownLimit) {
			    doorGo = true;
				transform.position = new Vector3 (transform.position.x, transform.position.y - Speed / 50, transform.position.z);
			}
		    if (transform.position.y <= DownLimit) {
			    doorGo = false;
		    }
	}

	IEnumerator WaitAndClose()
	{
		yield return new WaitForSeconds (CloseTime);
		if (doorOpenned) {
			if (player.GetComponent<AudioSource>().clip != Sound) {
				AudioSource.PlayClipAtPoint (Sound, transform.position);
			}
			doorOpenned = false;
		}
	}

	IEnumerator ShowAndClose()
	{
		ShowReqSuite = true;
		yield return new WaitForSeconds (2);
		ShowReqSuite = false;
	}

	void OnGUI()
	{
		if (ShowReqSuite)
		{
			GUI.Box(new Rect(Screen.width/2 - 90, Screen.height - 100, 220, 40), "Вы не подключены к системе");
		}
	}
}
