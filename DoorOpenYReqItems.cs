using UnityEngine;
using System.Collections;

public class DoorOpenYReqItems : MonoBehaviour {

	private GameObject player;
	public AudioClip Sound;
	public int Cards;
	private bool nocards = false;
	public int playerRange = 4;
	public int CloseTime = 3;
	public float Speed = 2.0f;
	public float UpLimit = -2f;
	public float DownLimit = -0f;
	public bool doorOpenned = false;
	private bool doorGo = false;

	void Start () {

		doorOpenned = false;
		nocards = false;
		player = GameObject.FindGameObjectWithTag("Player");

	}

	void Update () {

		Cards = player.GetComponent<CollectItemsDoorY>().Cards;

		if (Vector3.Distance (transform.position, player.transform.position) < playerRange) {

			if (Input.GetKeyDown(KeyCode.E) && !doorGo) {
				
				if (Cards == 2) {
					if (doorOpenned) {
						doorOpenned = false;
						AudioSource.PlayClipAtPoint (Sound, transform.position);
					} else {
						doorOpenned = true;
						AudioSource.PlayClipAtPoint (Sound, transform.position);
						StartCoroutine (WaitAndClose());
					}
				} else 
				{
					StartCoroutine(checkcards());
				}
			}

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

	IEnumerator checkcards()
	{
		nocards = true;
		yield return new WaitForSeconds (2);
		nocards = false;
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

	void OnGUI()
	{   
		if (nocards)
		{
			GUI.Box(new Rect(Screen.width/2 - 70, Screen.height - 100, 220, 40), "У вас нет допуска на этот уровень");
		}
	}
}