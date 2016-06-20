using UnityEngine;
using System.Collections;

public class VoiceTrigger : MonoBehaviour 
{
	public AudioClip voice;
	public GameObject trigger;
	public string TextMission;
	private bool isEnabled;
	public bool DisableTrigger;
	public float voicevolume = 0.5F;
	private GameObject player;
	private GameObject voicesource;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		voicesource = GameObject.FindGameObjectWithTag ("VoiceSuite");
		isEnabled = true;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player" && isEnabled)
		{
			if (DisableTrigger) 
			{
				trigger.GetComponent<AudioSource> ().enabled = false;

			}
			    //AudioSource.PlayClipAtPoint(voice, transform.position, voicevolume);
				voicesource.GetComponent<AudioSource> ().PlayOneShot (voice, voicevolume);
			    player.GetComponent<TabScreen> ().TextLabel1 = TextMission;
			    isEnabled = false;
		}
	}

}