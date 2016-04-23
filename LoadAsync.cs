using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadAsync : MonoBehaviour 
{
	AsyncOperation async;

	public int levelToLoad = 1;

    [HideInInspector]
    public float loadProgress = 0f;
    public bool loadAfterCompletion = false;
    public bool isLoad = true;
    public bool isAsync = false;

    void Update()
    {
    	if(isAsync)
    	{
    		loadProgress = async.progress;
    		//print(loadProgress);
    	}
    }

	IEnumerator Start() 
	{
        if(!Application.isEditor)
        {
            isLoad = true;
        }

        if (!Application.isEditor)
        {        
            async = SceneManager.LoadSceneAsync(levelToLoad);
            async.allowSceneActivation = loadAfterCompletion;         
            yield return async;
        }
        else if(isAsync)
        {        	
            async = SceneManager.LoadSceneAsync(levelToLoad);
            async.allowSceneActivation = loadAfterCompletion;        
            yield return async;
        }
	}

	public void ActivateLevel()
	{
        if (!Application.isEditor)
        {
            async.allowSceneActivation = true;
        }
        else
        {
            if (isLoad)
            {
                if (isAsync)
                {
                    async.allowSceneActivation = true;
                }
                else
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
        }
	}

    public void ActivateLevelDelay(float _delayTime)
    {
        Invoke("ActivateLevel", _delayTime);
    }
}

