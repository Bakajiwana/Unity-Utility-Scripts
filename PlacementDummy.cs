using UnityEngine;
using System.Collections;

public class PlacementDummy : MonoBehaviour 
{
	void Awake()
	{
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		this.enabled = false;
	}
}
