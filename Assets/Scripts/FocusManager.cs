using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FocusManager
{
	public static FocusManager instance = new FocusManager();
	public GameObject focus;
	public List<GameObject> focusable;
	public int focusIndex;
	public const int MAX_FOCUSABLES = 11;
	// Count of all the clones that were created since start of game.
	public int cloneTotalCount = 2;
	
	public FocusManager ()
	{
		focusable = new List<GameObject>();
	}
	
	public void nextFocus()
	{
		incrementIndex();
		setFocus();
	}
	
	private void incrementIndex()
	{
		focusIndex = (focusIndex + 1) % focusable.Count;
	}
	
	public void setFocus()
	{
		focus = focusable[focusIndex];
	}
	
	public bool isMainCamFocus()
	{
		if (focusExists())
		{
			return focus.tag == "MainCamera";
		}
		return false;
	}
	
	public void addFocusable(GameObject obj)
	{
		focusable.Add(obj);
		setFocus();
	}
	
	public void addFocusables(GameObject[] objs)
	{
		focusable.AddRange(objs);
		setFocus();
	}
	
	public void removeFocusable(GameObject obj)
	{
		focusable.Remove(obj);
	}
	
	public bool canAddFocusable()
	{
		return focusable.Count < MAX_FOCUSABLES;
	}
	
	public bool focusExists()
	{
		return focus != null;
	}
	
	public bool focusIndexExists()
	{
		return focusIndex < focusable.Count;
	}
	
	public void setToLastIndex()
	{
		focusIndex = focusable.Count - 1;
	}
}