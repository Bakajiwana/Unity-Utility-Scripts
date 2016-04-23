using UnityEngine;
using System.Collections;

public class ActivateAwakeScript : MonoBehaviour 
{
	public GameObject[] awakenObjects;
    public bool[] awakenActivate;

	void Awake()
	{
		for(int i = 0; i < awakenObjects.Length; i++)
		{
			awakenObjects[i].SetActive (awakenActivate[i]);
		}
	}
}
