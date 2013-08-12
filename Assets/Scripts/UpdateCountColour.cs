using UnityEngine;
using System.Collections;

public class UpdateCountColour : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		int focusableCount = FocusManager.instance.focusable.Count;
		if (focusableCount == FocusManager.MAX_FOCUSABLES)
		{
			gameObject.guiText.material.color = Color.red;
		}
		else
		{
			gameObject.guiText.material.color = Color.white;
		}	
	}
}
