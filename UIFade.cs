using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIFade : MonoBehaviour 
{
	public CanvasGroup canvas;
	public float fadeSpeed = 2f;

	public bool fade = false;

	public bool animateFade = false;

    public bool blockRaycastWhenVisible = false;

    public bool fadeOutOnTimer = false;
    public float fadeOutTimer = 2f;

    public UIFade fadePrevious;

    void Awake()
    {
        if(!canvas && gameObject.GetComponent<CanvasGroup>())
        {
            canvas = gameObject.GetComponent<CanvasGroup>();
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(fade)
		{
			if(canvas.alpha < 1f)
			{
				canvas.alpha += Time.deltaTime * fadeSpeed;

				if(canvas.alpha >= 1f)
				{
					if(animateFade)
					{
						fade = false;
					}
				}
			}
		}
		else
		{
			if(canvas.alpha > 0f)
			{
				canvas.alpha -= Time.deltaTime * fadeSpeed;

				if(canvas.alpha <= 0f)
				{
					if(!animateFade)
					{
						//gameObject.SetActive (false);
					}
					else
					{
						fade = true;
					}
				}
			}
		}
	}

	public void FadeTrigger(bool _trigger)
	{
		fade = _trigger;

        if(blockRaycastWhenVisible)
        {
            canvas.blocksRaycasts = _trigger;
        }

        if(fadeOutOnTimer && _trigger)
        {
            Invoke("FadeOutOnTimer", fadeOutTimer);
        }

        if(_trigger)
        {
        	if(fadePrevious)
        	{
        		fadePrevious.FadeTrigger(false);
        	}
        }
	}

    void FadeOutOnTimer()
    {
        FadeTrigger(false);
    }
}
