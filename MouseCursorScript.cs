using UnityEngine;
using System.Collections;

public class MouseCursorScript : MonoBehaviour 
{
	public bool hideMouseCursor = true;

	public bool lockMouseCursor = false;

	// Use this for initialization
	void Start () 
	{
		if(hideMouseCursor)
		{
			HideCursor (true);
		}
		else
		{
			HideCursor (false);
		}
	}

	public void HideCursor(bool _hide)
	{
		if(_hide)
		{
			Cursor.visible = false;
			if(lockMouseCursor)
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
