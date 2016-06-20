using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class FlashLight : MonoBehaviour {
	
	public float maxBatteryLife = 120;
	public bool RunDrainEnable = true;
	public float RunDrain = 8;
	public float flickerStart = 5;
	public float flickerSpeed = 0.1f;
	public float curBatteryLife = 0;
	public Light linkedLight;
	bool isEnabled;
	private GameObject player;

	public Texture2D batteryTexture;
	public Texture2D batteryBarTexture;

	void  Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		isEnabled = false;
		linkedLight.enabled = false;
		player.GetComponent<FirstPersonController> ().OnSuite = true;
		if (curBatteryLife == 0) 
		{
			curBatteryLife = maxBatteryLife;
		}
	}

	void  Update ()
	{
		if(curBatteryLife > 0)
		{
			if(curBatteryLife > maxBatteryLife)
			{
				curBatteryLife = maxBatteryLife;
			}
			else
			{  
				if(isEnabled)
				{
					curBatteryLife -= Time.deltaTime;
				}
				if(curBatteryLife <= flickerStart)
				{
					float RandomNumber= Random.value;
					if(RandomNumber <= flickerSpeed)
					{
						linkedLight.enabled = true;
					}
					else
					{
						linkedLight.enabled = false;
					}
				}
				else
				{
					if(Input.GetKeyDown("f"))
					{
						if(linkedLight.enabled == false) 
						{
							linkedLight.enabled = true;
							isEnabled = true;
						}
						else
						{
							linkedLight.enabled = false;
							isEnabled = false;
						}
					}
				}
			}
		}
		else
		{
			curBatteryLife = 0;
			linkedLight.enabled = false;
		}

		if (curBatteryLife != 0 && RunDrainEnable) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				curBatteryLife -= RunDrain * Time.deltaTime;
			}
		}

	}

	void  OnGUI (){
		GUI.DrawTexture( new Rect(Screen.width - 60, 10, 50, 50), batteryTexture);

		float adjustBatteryBar= curBatteryLife * (36/maxBatteryLife);
		if(curBatteryLife <= maxBatteryLife/5)
		{
			GUI.color = Color.red;
		}
		else
		{
			GUI.color = Color.white;
		}
		GUI.BeginGroup( new Rect(Screen.width - 55, 28, adjustBatteryBar, 12.7f));
		GUI.DrawTexture( new Rect(0, 0, 36, 12.7f), batteryBarTexture);
		GUI.EndGroup();
	}
}