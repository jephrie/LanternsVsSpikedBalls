using UnityEngine;
using System.Collections;

public class FocusAlternator : MonoBehaviour {
	
	public const int CAM_LIGHT_SPOT_ANGLE = 55;
	public const int CAM_LIGHT_INTENSITY = 12;
	public const int OBJ_LIGHT_SPOT_ANGLE = 15;
	public const int OBJ_LIGHT_INTENSITY = 10;
	public string buttonName;
	// The position the spotlight should be when the main camera is the focus.
	public Transform spotLightDefaultPos;
	// The starting positon of the main camera.
	public Transform defaultCamPos;
	private float smooth = 4f;
	
	// Use this for initialization
	void Start () {
		GameObject mainCam = GameObject.FindWithTag("MainCamera");
		FocusManager.instance.addFocusable(mainCam);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(buttonName))
		{
			FocusManager.instance.nextFocus();
		}
		
		if (FocusManager.instance.focusExists())
		{
			lerpLight ();
			lookAtFocus();
		}
		else
		{
			// If object was destroyed while focusing, move to the "next" focus. The "next" focus is:
			// 	- The object at the current index, if it exists
			// 	- The last object in the list
			if (FocusManager.instance.focusIndexExists())
			{
				FocusManager.instance.setFocus();
			}
			else
			{
				FocusManager.instance.setToLastIndex();
				FocusManager.instance.setFocus();
			}
		}
	}

	private void lerpLight ()
	{
		// Lerp the light so that it follows the current focus. Only move along the x and z axis.
		// Also, change the spot angle and intensity when focusing on a small object.
		if (FocusManager.instance.isMainCamFocus())
		{
			light.transform.position = Vector3.Lerp(light.transform.position, spotLightDefaultPos.position, smooth * Time.deltaTime);
			light.spotAngle = Mathf.Lerp(light.spotAngle, CAM_LIGHT_SPOT_ANGLE, smooth * Time.deltaTime);
			light.intensity = Mathf.Lerp(light.intensity, CAM_LIGHT_INTENSITY, smooth * Time.deltaTime);
		}
		else
		{
			Vector3 newPosition = FocusManager.instance.focus.transform.position;
			newPosition.y = light.transform.position.y;
			light.transform.position = Vector3.Lerp(light.transform.position, newPosition, smooth * Time.deltaTime);
			light.spotAngle = Mathf.Lerp(light.spotAngle, OBJ_LIGHT_SPOT_ANGLE, smooth * Time.deltaTime);
			light.intensity = Mathf.Lerp(light.intensity, OBJ_LIGHT_INTENSITY, smooth * Time.deltaTime);
		}
	}
	
	private void lookAtFocus()
	{
		Camera mainCam = FocusManager.instance.focusable[0].camera;
		if (FocusManager.instance.isMainCamFocus())
		{
			mainCam.transform.LookAt(defaultCamPos.transform);
			mainCam.transform.eulerAngles = defaultCamPos.transform.eulerAngles;
		}
		else
		{
			Transform focus = FocusManager.instance.focus.transform;
			mainCam.transform.LookAt(focus);
		}
	}
}
