using UnityEngine;
using System.Collections;

public class ColourAlternator : MonoBehaviour {
	
	public const int COLOURS_COUNT = 4;
	public Color[] colours = new Color[COLOURS_COUNT] {Color.white, Color.red, Color.green, Color.blue};
	public string buttonName;
	private int index = 0;
	private float smooth = 2f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(buttonName))
		{
			incrementIndex();
		}
		light.color = Color.Lerp(light.color, colours[index], smooth * Time.deltaTime);
	}
	
	private void incrementIndex()
	{
		index = (index + 1) % COLOURS_COUNT;
	}
}
