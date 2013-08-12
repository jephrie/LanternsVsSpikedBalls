using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {
	
	public string keyName;
	private FocusableObject inst;
	
	void Awake()
	{
		inst = gameObject.GetComponent<FocusableObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton(keyName) && gameObject.activeSelf && !inst.hasDropped)
		{
			rigidbody.isKinematic = false;
			rigidbody.useGravity = true;
			gameObject.isStatic = false;
			
			// Add the dropped object to the list of focusable objects.
			FocusManager.instance.addFocusable(gameObject);
			
			inst.cloneCountdown = 1f;
			inst.hasDropped = true;
		}
		
		if (inst.hasCloned)
		{
			// After the object has dropped and cloned itself, it cannot drop again.
			Destroy(GetComponent<Drop>());
			Destroy (GetComponent<DropSwitch>());
		}
	}
}
