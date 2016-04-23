using UnityEngine;
using System.Collections;

public class UIAnimationTrigger : MonoBehaviour 
{
	public Animator anim;

	public bool useMemoryString = false;
	public string memoryString;

	public void AnimationTrigger()
	{
		anim.SetTrigger ("AnimToggle");

		if(useMemoryString)
		{
			if(PlayerPrefs.GetInt (memoryString) == 0)
			{
				PlayerPrefs.SetInt(memoryString, 1);
			}
			else
			{
				PlayerPrefs.SetInt(memoryString, 0);
			}
		}
	}

	void Start()
	{
		if(useMemoryString)
		{
			if(useMemoryString)
			{
				if(PlayerPrefs.GetInt(memoryString) == 1)
				{
					anim.SetTrigger ("AnimToggle");
				}
			}
		}
	}
}
