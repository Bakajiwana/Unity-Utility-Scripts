using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour 
{
	public Transform target;

	public Transform[] lookWith;

	public Transform[] revealWhenLooking;
	
	private float lookTimer = 0f;
	public float lookMaxTimer = 5f;

	void Update()
	{
		if(lookTimer > 0f)
		{
			lookTimer -= Time.deltaTime;

			for(int i = 0; i < lookWith.Length; i++)
			{
				lookWith[i].LookAt (target.position);
			}

			if(lookTimer <=0f)
			{
				for(int i =0; i < revealWhenLooking.Length; i++)
				{
					revealWhenLooking[i].gameObject.SetActive (false);
				}
			}
		}
	}

	public void LookAtTarget()
	{
		if(!target)
		{
			if(GameObject.FindGameObjectWithTag ("Player"))
			{
				target = GameObject.FindGameObjectWithTag ("Player").transform;
			}
		}

		if(target)
		{
			lookTimer = lookMaxTimer;

			for(int i =0; i < revealWhenLooking.Length; i++)
			{
				revealWhenLooking[i].gameObject.SetActive (true);
			}
		}
	}
}
