using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("LightSwitch"))
		{
			gameObject.light.enabled = !gameObject.light.enabled;
		}
	}
}
