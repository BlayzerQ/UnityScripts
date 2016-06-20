using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		if (player != null) {
			transform.LookAt (player.transform);
		}
	}
}
