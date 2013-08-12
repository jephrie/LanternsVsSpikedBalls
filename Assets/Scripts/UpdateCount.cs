using UnityEngine;
using System.Collections;

public class UpdateCount : MonoBehaviour {
	
	public int maxFocusables;
		
	// Use this for initialization
	void Start () {
		// Max focusable pertains to all those that have been dropped.
		// -1 because the main camera doesn't really count as a droppable and focusable object
		maxFocusables = FocusManager.MAX_FOCUSABLES - 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		int activeFocusableCount = FocusManager.instance.focusable.Count - 1;
		
		string usedResources = activeFocusableCount.ToString();
		if (activeFocusableCount < 10)
		{
			usedResources = "0" + usedResources;
		}
		
		gameObject.guiText.text = usedResources+"/"+maxFocusables.ToString();
	}
}
