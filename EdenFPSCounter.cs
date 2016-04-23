using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Custom FPS Counter

public class EdenFPSCounter : MonoBehaviour
{
	//FPS Count
	public static int fps = 0;
	private int fpsCount = 0;

	public Text fpsText;

	void Start()
	{
		StartCoroutine(CountFPS());
	}

	void Update()
	{
		fpsCount++;
	}

	IEnumerator CountFPS()
	{
		while(true)
		{
			//For every one second count fps
			yield return new WaitForSeconds(1f);

			fps = fpsCount;
			fpsCount = 0;
			
			if(fpsText)
			{
				fpsText.text = fps.ToString();
			}

		}
	}
}
