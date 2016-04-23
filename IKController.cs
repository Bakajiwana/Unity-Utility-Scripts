using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKController : MonoBehaviour
{
    protected Animator anim;
    //IK Control Variables
    [Header("IK Controls")]
    [Tooltip("Check if you want IK to be controlled. Special Note: All Array Sizes Must Be Equal! Indices are Shared.")]
    public bool[] ikActive;

    [Tooltip("Choose which Humanoid IK you want controlled. Special Note: All Array Sizes Must Be Equal! Indices are Shared.")]
    public IKHandle[] ikHandleController;

    [Tooltip("Set the Max Weight of the IK Control, There's a public function called SetIKWeight(bool[] _weights) to set edit this." + 
        " Special Note: All Array Sizes Must Be Equal! Indices are Shared.")]
    [Range(0f,1f)]
    public float[] ikWeight;

    [Tooltip("The objects the specific IK is following. Special Note: All Array Sizes Must Be Equal! Indices are Shared.")]
    public Transform[] followObj;

    public bool startWithIK = false;

    //Lerp Weights Randomly
    [Header("Lerp Weights Randomly (Optional)")]
    [Tooltip("Lerps IK Weights at Random times. Special Note: All Array Sizes Must Be Equal! Indices are Shared.")]
    public bool[] animateIKWeightsAtRandomTimes;
    public float ikWeightRandomMinTime = 0f;
    public float ikWeightRandomResetTime = 5f;
    private float ikWeightTimer;
    private bool isIncrease = false;
    public bool ikRandomWeights = false;
    public bool ikRandomDecrease = false;
    public bool ikRandomIncrease = false;
    private float ikRandomWeightMin;
    private float ikRandomWeightMax;
    [Range(0f, 1f)]
    public float ikWeightMin = 0f;
    [Range(0f, 1f)]
    public float ikWeightMax = 1f;
    public float ikWeightSpeed = 1f;

    //Animation Layer Override
    [Header("Animation Layer Override (Optional)")]
    [Tooltip("Choose whether you want the first IK Weight Value to override an animation layer weight")]
    public bool animLayerEqualsWeightValue = false;
    public int animLayer = 0;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        ikWeightTimer = ikWeightRandomResetTime;

        if(startWithIK)
        {
            Invoke("TurnOnIK", 1f);
        }
    }

    void Update()
    {
        //Animate IK Weight thresholds
        for (int i = 0; i < animateIKWeightsAtRandomTimes.Length; i++)
        {
            if (animateIKWeightsAtRandomTimes[i])
            {
                ikWeightTimer -= Time.deltaTime;

                //Lerp 
                if (isIncrease)
                {
                    //Increase over time
                    if (ikRandomWeights)
                    {
                       if (ikWeight[i] < ikRandomWeightMax)
                        {
                            ikWeight[i] += Time.deltaTime * ikWeightSpeed;
                        }
                    }
                    else
                    {                     
                        if (ikWeight[i] < ikWeightMax)
                        {
                            ikWeight[i] += Time.deltaTime * ikWeightSpeed;
                        }
                    }
                }
                else
                {
                    //Decrease over time
                    if (ikRandomWeights)
                    {
                        if (ikWeight[i] > ikRandomWeightMin)
                        {
                            ikWeight[i] -= Time.deltaTime * ikWeightSpeed;
                        }
                    }
                    else
                    {
                        if (ikWeight[i] > ikWeightMin)
                        {
                            ikWeight[i] -= Time.deltaTime * ikWeightSpeed;
                        }
                    }
                }

                if (ikWeightTimer <= 0f)
                {
                    //Reset Timer
                    ikWeightTimer = Random.Range(ikWeightRandomMinTime, ikWeightRandomResetTime);
                    //print(ikWeightTimer); //Debug

                    if(ikRandomWeights)
                    {
                        if(ikRandomDecrease)
                        {
                            //Randomise Weight
                            ikRandomWeightMin = Random.Range(0f, ikWeightMin);                            
                        }
                        else
                        {
                            ikRandomWeightMin = ikWeightMin;
                        }
                        if(ikRandomIncrease)
                        {
                            ikRandomWeightMax = Random.Range(ikWeightMax, 1f);
                        }
                        else
                        {
                            ikRandomWeightMax = ikWeightMax;
                        }

                        //Debug
                        //print(transform.name + " min IK weight equals " + ikRandomWeightMin);
                        //print(transform.name + " max IK weight equals " + ikRandomWeightMax);                    
                    }

                    //Switch to isIncrease
                    isIncrease = !isIncrease;
                }

                if(animLayerEqualsWeightValue)
                {
                    anim.SetLayerWeight(animLayer, ikWeight[0]);
                }
            }
        }
    }

	// A callback for calculating IK
    void OnAnimatorIK()
    {
        //If there is an animator component then continue
        if(anim)
        {
            //If IK is active, set the position and rotation directly to the follow object
            for(int i = 0; i < ikActive.Length; i++)
            {
                if(ikActive[i] == true)
                {
                    if(followObj[i] != null)
                    {                        
                        switch(ikHandleController[i])
                        {                            
                            case IKHandle.Head:         //Set the look target position, if one has been assigned
                                anim.SetLookAtWeight(ikWeight[i]);
                                anim.SetLookAtPosition(followObj[i].position);
                                break;
                            case IKHandle.LeftHand:     //Set the Left hand Target
                                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight[i]);
                                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, ikWeight[i]);
                                anim.SetIKPosition(AvatarIKGoal.LeftHand, followObj[i].position);
                                anim.SetIKRotation(AvatarIKGoal.LeftHand, followObj[i].rotation);
                                break;
                            case IKHandle.RightHand:    //Set the right hand target
                                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight[i]);
                                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, ikWeight[i]);
                                anim.SetIKPosition(AvatarIKGoal.RightHand, followObj[i].position);
                                anim.SetIKRotation(AvatarIKGoal.RightHand, followObj[i].rotation);
                                break;
                            case IKHandle.LeftFoot:     //Set the left foot target
                                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, ikWeight[i]);
                                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, ikWeight[i]);
                                anim.SetIKPosition(AvatarIKGoal.LeftFoot, followObj[i].position);
                                anim.SetIKRotation(AvatarIKGoal.LeftFoot, followObj[i].rotation);
                                break;
                            case IKHandle.RightFoot:    //Set the right foot target
                                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, ikWeight[i]);
                                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, ikWeight[i]);
                                anim.SetIKPosition(AvatarIKGoal.RightFoot, followObj[i].position);
                                anim.SetIKRotation(AvatarIKGoal.RightFoot, followObj[i].rotation);
                                break;
                        }
                    }
                }
                else
                {
                    switch (ikHandleController[i])
                    {
                        case IKHandle.Head:         //Set the look target position, if one has been assigned
                            anim.SetLookAtWeight(0);
                            break;
                        case IKHandle.LeftHand:     //Set the Left hand Target
                            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                            break;
                        case IKHandle.RightHand:    //Set the right hand target
                            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                            break;
                        case IKHandle.LeftFoot:     //Set the left foot target
                            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
                            break;
                        case IKHandle.RightFoot:    //Set the right foot target
                            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
                            break;
                    }
                }
            }
        }
    }

    public void SetIKWeight(float[] _weight)
    {
        for(int i = 0; i < ikWeight.Length; i++)
        {
            ikWeight[i] = _weight[i];
        }
    }

    public void TurnOffIK()
    {
        isIncrease = false;
    }

    public void TurnOnIK()
    {
        isIncrease = true;
    }

    public enum IKHandle
    {
        Head,
        LeftHand,
        RightHand,
        LeftFoot,
        RightFoot
    }
}
