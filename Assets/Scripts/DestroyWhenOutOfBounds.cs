using UnityEngine;
using System.Collections.Generic;

public class DestroyWhenOutOfBounds : MonoBehaviour {
	
	private List<GameObject> objectsToKill;
	private List<GameObject> finishedKillSequence;
	public const float colourSmooth =10f;
	public const float scaleSmooth = 1.5f;
	public static float endScaleMagnitude = Mathf.Pow(0.3f, 2f) * 3;
	
	// Use this for initialization
	void Start () {
		objectsToKill = new List<GameObject>();
		finishedKillSequence = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		// Destroy any objects that have finished playing the kill animation sequence from last frame.
		for (int j = 0; j < finishedKillSequence.Count; j++)
		{
			Destroy(finishedKillSequence[j]);
		}
		
		// Play the kill animation sequence for objects that have escaped out of bounds.
		for (int i = 0; i < objectsToKill.Count; i++)
		{
			if (objectsToKill[i] != null)
			{
				playKillSequence (i);
			}
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		Transform p = other.transform.parent;
		if (p != null)
		{
			objectsToKill.Add(p.gameObject);
		}
	}

	public void playKillSequence (int i)
	{
		GameObject obj = objectsToKill[i];
		objectsToKill[i].rigidbody.isKinematic = true;
		MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
		bool finishedLerping = true;
		
		foreach(MeshRenderer r in renderers)
		{
			// Lerp the colour to red.
			Color c = Color.Lerp(r.material.color, Color.red, Time.deltaTime * colourSmooth);
			r.material.color = c;
			
			// Lerp the scale to zero.
			Vector3 s = Vector3.Lerp(r.transform.localScale, Vector3.zero, Time.deltaTime * scaleSmooth);
			r.transform.localScale = s;
			
			// true if current and all previous renderers in this loop have finished lerping.
			// false if current renderer hasn't finished lerping.
			finishedLerping = finishedLerping && c == Color.red && s.magnitude <= endScaleMagnitude;
		}
		
		// If all mesh renderers have finished lerping, remove the object from the focusable list, then destroy it.
		if (finishedLerping)
		{
			objectsToKill.RemoveAt(i);
			FocusManager.instance.removeFocusable(obj);
			finishedKillSequence.Add(obj);
			Destroy(obj);
		}
	}
}
