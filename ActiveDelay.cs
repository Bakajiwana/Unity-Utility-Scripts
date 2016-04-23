using UnityEngine;
using System.Collections;

public class ActiveDelay : MonoBehaviour 
{
	public Transform spawnObject;
	public float delay;

	// Use this for initialization
	void Start () 
	{
		spawnObject.gameObject.SetActive (false);

		Invoke ("Spawn", delay);
	}

	void Spawn()
	{
		spawnObject.gameObject.SetActive (true);
	}
}
