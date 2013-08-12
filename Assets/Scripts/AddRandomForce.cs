using UnityEngine;
using System.Collections;

public class AddRandomForce : MonoBehaviour {
	
	private float maxForce = 1800f;
	private float maxYForce = 1000f;
	private float maxTorque = 1000f;
	private float cooldown = 2f;
	private FocusableObject inst;
	
	void Awake()
	{
		inst = gameObject.GetComponent<FocusableObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inst.hasDropped)
		{
			if (cooldown <= 0)
			{
				float x = Random.Range(-maxForce, maxForce);
				float y = Random.Range(-maxYForce/2, maxYForce);
				float z = Random.Range(-maxForce, maxForce);
				gameObject.rigidbody.AddForce(new Vector3(x, y, z));
				
				float tx = Random.Range(-maxTorque, maxTorque);
				float ty = Random.Range(-maxTorque, maxTorque);
				float tz = Random.Range(-maxTorque, maxTorque);
				gameObject.rigidbody.AddTorque(new Vector3(tx, ty, tz));
				
				cooldown = 3f;
			}
			else
			{
				cooldown -= Time.deltaTime;
			}
		}
	}
}