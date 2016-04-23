using UnityEngine;
using System.Collections;

public class ComponentActivator : MonoBehaviour 
{
	public MonoBehaviour [] scripts; 

	public float delayTime = 2f;

	void Awake()
	{
		Invoke ("ActivateComponents", delayTime);
	}

	void ActivateComponents()
	{
		for(int i = 0; i < scripts.Length; i++)
		{
			scripts[i].enabled = true;
		}
	}
}
