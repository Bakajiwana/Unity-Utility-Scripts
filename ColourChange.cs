using UnityEngine;
using System.Collections;

public class ColourChange : MonoBehaviour 
{
	public Material[] sceneMaterials;

	public Color[] tintColour;
	public Color[] emitColour;

	private Color alertColour = Color.red;
	private Color standardColor = Color.white;

	public static bool turnOnAlert = false;
	public static bool turnOffAlert = false;

	private float timer = 10f;


	// Use this for initialization
	void Start () 
	{
		NormalColourChange();
	}

	void Update()
	{
		if(turnOnAlert)
		{
			AlertColourChange (true);
			turnOnAlert = false;
		}

		if(turnOffAlert)
		{
			AlertColourChange (false);
			turnOffAlert = false;
		}

		if(Application.isEditor)
		{
			if(Input.GetKeyDown(KeyCode.Home))
			{
				ReturnColour ();
			}
		}

		if(timer > 0f)
		{
			timer -= Time.deltaTime;

			if(timer <= 0f)
			{
				NormalColourChange();
			}
		}
	}

	public void NormalColourChange()
	{
		for(int i = 0; i < sceneMaterials.Length; i++)
		{
			sceneMaterials[i].SetColor ("_Color", tintColour[i]);
			sceneMaterials[i].SetColor ("_EmitColor", emitColour[i]);
		}
	}

	public void ReturnColour()
	{
		for(int i = 0; i < sceneMaterials.Length; i++)
		{
			sceneMaterials[i].SetColor ("_Color", standardColor);
			sceneMaterials[i].SetColor ("_EmitColor", standardColor);
		}
	}

	public void AlertColourChange(bool currentAlert)
	{
		if(currentAlert)
		{
			for(int i = 0; i < sceneMaterials.Length; i++)
			{
				sceneMaterials[i].SetColor ("_Color", alertColour);
				sceneMaterials[i].SetColor ("_EmitColor", alertColour);
			}

			timer = 10f;
		}
		else
		{
			if(timer <= 0f)
			{
				NormalColourChange();
			}
		}
	}
}
