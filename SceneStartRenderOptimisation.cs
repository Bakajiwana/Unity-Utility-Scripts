using UnityEngine;
using System.Collections;

public class SceneStartRenderOptimisation : MonoBehaviour 
{
	private MeshRenderer[] meshes;

	private float activateTimer = 0.005f;
	private int meshIndex = 0;

	// Use this for initialization
	void Awake () 
	{
		//Get Every Mesh from Children into array
		meshes = gameObject.GetComponentsInChildren <MeshRenderer>();

		//Disable all of them
		foreach(MeshRenderer thing in meshes)
		{
			thing.enabled = false;
		}

		//Invoke Repeat the Activate function with delay
		InvokeRepeating ("ActivateMeshes", 0f, activateTimer);
	}
	
	void ActivateMeshes()
	{
		//Turn on current mesh
		meshes[meshIndex].enabled = true;
		meshIndex ++;

		//if that's all of the meshes then turn this script off
		if(meshIndex >= meshes.Length)
		{
			this.enabled = false;
			CancelInvoke ();
		}
	}
}
