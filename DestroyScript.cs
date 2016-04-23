using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour 
{
	public float destroyTime;

	public GameObject specificObject;

	public bool destroyOnAnimationOverride = false;

	// Use this for initialization
	void Start () 
	{
		if(!destroyOnAnimationOverride)
		{
			DestroySelf ();
		}
	}

	public void DestroySelf()
	{
		if(specificObject)
		{
			Destroy (specificObject, destroyTime);
		}
		else
		{
			Destroy (gameObject, destroyTime);
		}
	}
}
