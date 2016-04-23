using UnityEngine;
using System.Collections;

public class HideMouse : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        if (!Application.isEditor)
        {
            Cursor.visible = false;
        }
	}
}
