using UnityEngine;
using System.Collections;

public class RotationOverride : MonoBehaviour 
{
	public bool overrideX;
	public float valueX;
	
	public bool overrideY;
	public float valueY;
	
	public bool overrideZ;
	public float valueZ;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPos = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		
		if(overrideX)
		{
			newPos.x = valueX;
		}
		
		if(overrideY)
		{
			newPos.y = valueY;
		}
		
		if(overrideZ)
		{
			newPos.z = valueZ;
		}
		
		transform.eulerAngles = newPos;
	}
}
