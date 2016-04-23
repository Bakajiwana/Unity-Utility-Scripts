using UnityEngine;
using System.Collections;

public class TriggerSendMessage : MonoBehaviour
{
	[Header("Send Message Objects")]
	public GameObject[] sendMessageObjects;
	public string[] sendEnterMessages;
	public string[] sendExitMessages;

	[Header("Trigger Options")]
	public bool triggerOnTag = false;
	public string tagID;
	public GameObject triggerOnObject;

	[Header("Send Message Options")]
	public bool sendEnterMessageOnStart = false;
	public bool sendExitMessageOnStart = false;
	public bool sendEnterMessagesOnEnable = false;
	public bool sendExitMessagesOnEnable = false;
	public bool sendEnterMessagesOnDisable = false;
	public bool sendExitMessagesOnDisable = false;

	[Header("Send Message Parameters On Enter")]
	public ParameterType parameterEnterType = ParameterType.None;
	public int intEnterParameter;
	public float floatEnterParameter;
	public string stringEnterParameter;
	public int[] intArrayEnterParamenter;
	public float[] floatArrayEnterParameter;
	public string[] stringArrayEnterParameter;

	[Header("Send Message Parameters On Exit")]
	public ParameterType parameterExitType = ParameterType.None;
	public int intExitParameter;
	public float floatExitParameter;
	public string stringExitParameter;
	public int[] intArrayExitParamenter;
	public float[] floatArrayExitParameter;
	public string[] stringArrayExitParameter;

	// Use this for initialization
	void Start ()
	{
		if (sendEnterMessageOnStart)
		{
			MessageObjectsOnEnter();
		}

		if(sendExitMessageOnStart)
		{
			MessageObjectsOnExit();
		}
	}

	void OnEnable()
	{
		if(sendEnterMessagesOnEnable)
		{
			MessageObjectsOnEnter();
		}

		if(sendExitMessagesOnEnable)
		{
			MessageObjectsOnExit();
		}
	}

	void OnDisable()
	{
		if(sendEnterMessagesOnDisable)
		{
			MessageObjectsOnEnter();
		}

		if(sendExitMessagesOnDisable)
		{
			MessageObjectsOnExit();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (triggerOnTag)
		{
			if (other.gameObject.CompareTag(tagID))
			{
				MessageObjectsOnEnter();
			}
		}
		else
		{
			if (other.gameObject == triggerOnObject)
			{
				MessageObjectsOnEnter();
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (triggerOnTag)
		{
			if (other.gameObject.CompareTag(tagID))
			{
				MessageObjectsOnExit();
			}
		}
		else
		{
			if (other.gameObject == triggerOnObject)
			{
				MessageObjectsOnExit();
			}
		}
	}

	public void MessageObjectsOnEnter()
	{
		for (int i = 0; i < sendMessageObjects.Length; i++)
		{
			switch ((int)parameterEnterType)
			{
			case 0:
				sendMessageObjects[i].SendMessage(sendEnterMessages[i], SendMessageOptions.RequireReceiver);
				break;
			case 1:
				sendMessageObjects[i].SendMessage(sendEnterMessages[i], intEnterParameter, SendMessageOptions.RequireReceiver);
				break;
			case 2:
				sendMessageObjects[i].SendMessage(sendEnterMessages[i], floatEnterParameter, SendMessageOptions.RequireReceiver);
				break;
			case 3:
				sendMessageObjects[i].SendMessage(sendEnterMessages[i], stringEnterParameter, SendMessageOptions.RequireReceiver);
				break;
			case 4:
				sendMessageObjects[i].SendMessage(sendEnterMessages[i], intArrayEnterParamenter, SendMessageOptions.RequireReceiver);
				break;
			case 5:
				sendMessageObjects[i].SendMessage(sendEnterMessages[i], floatArrayEnterParameter, SendMessageOptions.RequireReceiver);
				break;
			case 6:
				sendMessageObjects[i].SendMessage(sendEnterMessages[i], stringArrayEnterParameter, SendMessageOptions.RequireReceiver);
				break;
			}
		}
	}

	public void MessageObjectsOnExit()
	{
		for (int i = 0; i < sendMessageObjects.Length; i++)
		{
			switch ((int)parameterExitType)
			{
			case 0:
				sendMessageObjects[i].SendMessage(sendExitMessages[i], SendMessageOptions.RequireReceiver);
				break;
			case 1:
				sendMessageObjects[i].SendMessage(sendExitMessages[i], intExitParameter, SendMessageOptions.RequireReceiver);
				break;
			case 2:
				sendMessageObjects[i].SendMessage(sendExitMessages[i], floatExitParameter, SendMessageOptions.RequireReceiver);
				break;
			case 3:
				sendMessageObjects[i].SendMessage(sendExitMessages[i], stringExitParameter, SendMessageOptions.RequireReceiver);
				break;
			case 4:
				sendMessageObjects[i].SendMessage(sendExitMessages[i], intArrayExitParamenter, SendMessageOptions.RequireReceiver);
				break;
			case 5:
				sendMessageObjects[i].SendMessage(sendExitMessages[i], floatArrayExitParameter, SendMessageOptions.RequireReceiver);
				break;
			case 6:
				sendMessageObjects[i].SendMessage(sendExitMessages[i], stringArrayExitParameter, SendMessageOptions.RequireReceiver);
				break;
			}
		}
	}

	public enum ParameterType {None, Int, Float, String, IntArray, FloatArray, StringArray}
}
