using UnityEngine;
using System.Collections;

//Script Objective: Re-useable script used to switch objects between arrays or can be accessed to switch objects
public class SwitcherScript : MonoBehaviour
{
    [Header("Controls")]
    public bool useKeySwitch = true;    //Whether or not we want to switch with a keycode
    public KeyCode switchBtn = KeyCode.L;

    [Header("Switch Objects")]
    public bool switchThroughChildren;
    public GameObject[] switchObjs;
    public int switchIndex = 0;

    [Header("Randomisation")]
    public bool randomiseStartSwitch = false;

    void Start()
    {
        //If switchThroughChildren is true then this object will just switch through the child objects
        if (switchThroughChildren)
        {
            //Renew switchObjs Array with a size equal to the children under this game object
            switchObjs = new GameObject[transform.childCount];
  
            //Grab all gameobjects and shove them into the switchObjs array
            int i = 0;
            foreach (Transform child in transform)
            {
                switchObjs[i] = child.gameObject;
                //print("Foreach loop: " + switchObjs[i]);
                i++;
            }
        }

        if(randomiseStartSwitch)
        {
            switchIndex = Random.Range(0, switchObjs.Length - 1);
        }

        //Disable and Enable the correct objects as specified in the public switch index
        CorrectSwitch();        
    }
	
	// Update is called once per frame
	void Update ()
    {
	    //If Switch Button and enabled is pressed - Cycle between switch objects array
        if(Input.GetKeyUp(switchBtn) && useKeySwitch)
        {
            CycleObjects();
        }
	}

    //This procedure is called to disable all objects and enable the correct object
    public void CycleObjects()
    {
        if (switchObjs.Length > 0)
        {
            //Disable Everything in the array first
            foreach (GameObject obj in switchObjs)
            {
                obj.SetActive(false);
            }

            CycleIndex();

            //Enable the correct game object using switch index
            switchObjs[switchIndex].SetActive(true);
        }
    }

    public void CycleIndex()
    {
        //Increment Switch Index
        switchIndex++;
        //If switch index is greater than array length, reset back to 0
        if (switchIndex > switchObjs.Length - 1)
        {
            switchIndex = 0;
        }
    }

    public void SetSwitch(int _index)
    {
        if (switchObjs.Length > 0)
        {
            //Disable Everything in the array first
            foreach (GameObject obj in switchObjs)
            {
                obj.SetActive(false);
            }

            //Switch Index is set to _index variable
            switchIndex = _index;
            //If switch index is greater than array length, reset back to 0
            if (switchIndex > switchObjs.Length - 1)
            {
                switchIndex = 0;
            }

            //Enable the correct game object using switch index
            switchObjs[switchIndex].SetActive(true);
        }
    }

    //This procedure is mainly called in start up to Correct the gameobjects to be active or not active
    public void CorrectSwitch()
    {
        //Disable Everything in the array first
        foreach (GameObject obj in switchObjs)
        {
            obj.SetActive(false);
        }

        //Enable the correct game object using switch index
        switchObjs[switchIndex].SetActive(true);
    }
}
