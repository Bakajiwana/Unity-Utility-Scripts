using UnityEngine;
using System.Collections;

public class AnimateOnDistance : MonoBehaviour 
{
	public Animator anim;

	public string objectTag;

	public string enterTrigger;
	public string exitTrigger;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag (objectTag))
		{
			anim.SetTrigger (enterTrigger);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag (objectTag))
		{
			anim.SetTrigger (exitTrigger);
		}
	}
}
