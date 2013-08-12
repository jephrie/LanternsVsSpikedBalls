using UnityEngine;
using System.Collections;

public class FocusableObject : MonoBehaviour {
	
	public bool hasDropped = false;
	public bool hasCloned = false;
	public float cloneCountdown;
	
	private FocusableObject()
	{
	}
	
	public void reset()
	{
		hasDropped = false;
		hasCloned = false;
		cloneCountdown = 0f;
	}
	
	public void setActiveAllChildren(GameObject obj, bool isActive)
	{
		int childCount = obj.transform.GetChildCount();
		for (int i = 0; i < childCount; i++)
		{
			obj.transform.GetChild(i).gameObject.SetActive(isActive);
		}
	}
}
