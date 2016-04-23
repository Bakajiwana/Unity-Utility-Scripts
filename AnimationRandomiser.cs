using UnityEngine;
using System.Collections;

//Script Objective: Utility script to randomise animations

public class AnimationRandomiser : MonoBehaviour
{
    private Animator anim;

    [Tooltip("Only Int is supported at the moment")]
    [Header("Mecanim Parameters")]
    public string parameterName;
    public ParameterType parameterType;
    
    [Header("Random Timers")]
    public float randomMinTimer = .05f;
    public float randomMaxTimer = 5f;
    [Header("Animation Indices")]
    public int minIntAnimations;
    public int maxIntAnimations;
    [Header("Back to Default Option")]
    public bool backToDefault = false;
    public float backToDefaultTimer = 1f;
    public int defaultInt = 0;

	// Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

	void OnEnable ()
    {
        //Restart Invokes
        CancelInvoke();

        //Call Invoke Function
        if (parameterType == ParameterType.Int)
        {
            Invoke("RandomIntAnimation", Random.Range(randomMinTimer, randomMaxTimer));
        }
        else if (parameterType == ParameterType.Bool)
        {
            Invoke("RandomBoolAnimation", Random.Range(randomMinTimer, randomMaxTimer));
        }
    }

    public void RandomIntAnimation()
    {
        int random = Random.Range(minIntAnimations, maxIntAnimations);
        anim.SetInteger(parameterName, random);

        //Repeat with random time
        Invoke("RandomIntAnimation", Random.Range(randomMinTimer, randomMaxTimer));
        //Debug
        //print("Random Animation Int = " + anim.GetInteger("RandomIntAnimation"));

        if (backToDefault)
        {
            Invoke("BackToDefault", backToDefaultTimer);
        }
    }

    public void RandomBoolAnimation()
    {
        //Switch Bool
        bool boolValue = anim.GetBool(parameterName);
        boolValue = !boolValue;
        anim.SetBool(parameterName, boolValue);

        //Repeat with random time
        Invoke("RandomBoolAnimation", Random.Range(randomMinTimer, randomMaxTimer));
    }

    void BackToDefault()
    {
        if (parameterType == ParameterType.Int)
        {
            anim.SetInteger(parameterName, 0);
        }
    }

    public enum ParameterType {Int, Bool};
}
