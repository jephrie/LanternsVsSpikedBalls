using UnityEngine;
using System.Collections;

public class DropSwitch : MonoBehaviour {
	
	private Drop drop;
	private FocusableObject inst;
	
	void Awake()
	{
		drop = gameObject.GetComponent<Drop>();
		inst = gameObject.GetComponent<FocusableObject>();
	}
	
	void Update ()
	{
		if (!inst.hasDropped)
		{
			// There is a short time where an object is destroyed and undropped objects can be dropped.
			// When we encounter this, enable both the drop script and the children objects.
			// Also, there is a short time where all droppable objects are enabled, but one of them has been dropped, reaching the limit of dropped objects.
			// When we encounter this, disable both the drop script and the children objects. 
			if (FocusManager.instance.canAddFocusable() ^ drop.enabled)
			{
				bool isActive = !drop.enabled;
				drop.enabled = isActive;
				inst.setActiveAllChildren(gameObject, isActive);
			}
		}
	}
}
