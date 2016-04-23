using UnityEngine;
using System.Collections;

public class TranslateScript : MonoBehaviour
{
	public float moveSpeed = 2f;

	public Vector3 moveDirection;

	public bool worldSpace;

	
	// Update is called once per frame
	void Update () 
	{
		if(worldSpace)
		{
			transform.Translate (moveDirection * Time.deltaTime * moveSpeed, Space.World);
		}
		else
		{
			transform.Translate (moveDirection * Time.deltaTime * moveSpeed, Space.Self);
		}
	}
}
