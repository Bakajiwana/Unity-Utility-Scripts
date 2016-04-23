using UnityEngine;
using System.Collections;

public class ScalerScript : MonoBehaviour 
{
	public float scaleX;
	public float scaleY;
	public float scaleZ;
	
	// Update is called once per frame
	void Update () 
	{
		transform.localScale += new Vector3(scaleX, scaleY, scaleZ);
	}
}
