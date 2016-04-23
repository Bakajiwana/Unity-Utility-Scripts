using UnityEngine;
using System.Collections;

//This Script Instantiates effects: Instantiate Objects by message or a given rate

public class InstantiationScript : MonoBehaviour 
{
	public Transform spawnObject;

	public float delayTime = 0f;

	public bool repeatSpawn = false;
	public float repeatRate = 1f;

	public bool startSpawn = false;

	// Use this for initialization
	void Start () 
	{
		if(repeatSpawn)
		{
			InvokeRepeating ("SpawnObject", delayTime, repeatRate);
		}

		if(startSpawn)
		{
			Invoke ("SpawnObject", delayTime);
		}
	}
	
	public void SpawnDifferentObject(GameObject _spawnObject)
	{
		Instantiate (_spawnObject, transform.position, transform.rotation);
	}

	public void SpawnObject()
	{
		Instantiate (spawnObject, transform.position, transform.rotation);
	}	

	public void SpawnObjectAsChild()
	{
		Transform spawn = Instantiate (spawnObject, transform.position, transform.rotation) as Transform;
		spawn.SetParent (transform, true);

		spawn.localPosition = Vector3.zero;
	}
}
