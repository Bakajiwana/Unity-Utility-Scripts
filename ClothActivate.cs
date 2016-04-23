using UnityEngine;
using System.Collections;

public class ClothActivate : MonoBehaviour 
{
	public Cloth[] cloths;
	public float timeActivate = 1f;

	// Use this for initialization
	void Awake () 
	{
		foreach (Cloth clothObj in cloths)
		{
			clothObj.enabled = false;
		}
	}

	void Start()
	{
		Invoke ("ActivateCloth", timeActivate);
	}
	
	void ActivateCloth()
	{
		if(PlayerPrefs.GetInt ("MeshQuality") <= 1)
		{
			foreach (Cloth clothObj in cloths)
			{
				clothObj.enabled = true;
			}
		}
		this.enabled = false;
	}
}
