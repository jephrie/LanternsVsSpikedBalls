using UnityEngine;
using System.Collections;

public class Clone : MonoBehaviour {
	
	public Transform startPos;
	public GameObject prefab;
	private FocusableObject inst;
	
	void Awake()
	{
		inst = gameObject.GetComponent<FocusableObject>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (inst.hasDropped && !inst.hasCloned)
		{
			if (inst.cloneCountdown <= 0)
			{
				GameObject clone = Instantiate (prefab) as GameObject;
				
				// Change the clone name to something more useful.
				FocusManager.instance.cloneTotalCount++;
				string objName = name.Split(new char[] {'('})[0];	// ignore (*)
				clone.name = objName+"("+FocusManager.instance.cloneTotalCount+")";
				// Set clone to static
				clone.isStatic = true;
				// Move the clone to the starting position.
				clone.transform.position = startPos.transform.localPosition;
				// Set the clone as a kinematic object that doesn't use gravity.
				clone.rigidbody.isKinematic = true;
				clone.rigidbody.useGravity = false;
				// Reset clone's script values.
				FocusableObject cloneInst = clone.GetComponent<FocusableObject>();
				cloneInst.reset();
				// By default, disable the drop functionality when a new clone has been created. DropScriptSwitch will turn it on when required.
				inst.setActiveAllChildren(clone, false);
				Drop drop = clone.GetComponent<Drop>();
				drop.enabled = false;
				
				inst.hasCloned = true;
				
				// Once the object has cloned once, it loses the ability to clone again, so remove this script.
				Destroy(this);
			}
			else
			{
				inst.cloneCountdown -= Time.deltaTime;
			}
		}
	}
}
