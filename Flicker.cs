using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

	public Light lamp;
	private int rand;

	void Update () 
	{
		rand = Random.Range(0,1000);
		if(rand >= 980)
		{
			lamp.enabled = false;
		}
		else
		{
			lamp.enabled = true;
		}
	}
}
