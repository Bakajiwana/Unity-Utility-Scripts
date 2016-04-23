using UnityEngine;
using System.Collections;

public class UnparentScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		transform.SetParent (null);
	}
}
