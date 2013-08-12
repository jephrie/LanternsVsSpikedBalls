using UnityEngine;
using System.Collections;

public class UpdateFocusName : MonoBehaviour {
	
	void Start ()
	{
		gameObject.guiText.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (FocusManager.instance.focus != null)
		{
			string focusName = FocusManager.instance.focus.name;
			if (focusName == "Main Camera")
			{
				gameObject.guiText.text = "";
			}
			else
			{
				gameObject.guiText.text = focusName;
			}
		}
	}
}
