using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioMixerController : MonoBehaviour
{
	[Header("Audio Mixer Values")]
	public AudioMixer mixer;
	public string parameterName;

	[Header("On Enable Settings")]
	public bool activateOnEnable = false;
	public float enableValue;
	public bool lerpWhenEnable = false;
	[Tooltip("Make this a negative if you want to lerp backwards")]
	public float lerpEnableSpeed = 1f;
	private bool lerpEnable = false;

	[Header("On Disable Settings")]
	public bool activateOnDisable = false;
	public float disableValue;
	public bool lerpWhenDisable = false;
	[Tooltip("Make this a negative if you want to lerp backwards")]
	public float lerpDisableSpeed = 1f;
	private bool lerpDisable = false;

	[Header("Lerp Override Object")]
	[Tooltip("It's impossible to lerp when this object deactivates so an object with a lerp function is required")]
	public GameObject lerpSendMessageObject;
	public string lerpMessage;

	[Header("Settings Override")]
	public bool settingsOverride;
	public string overrideFunction;

	void Start()
	{
		//If Settings Override is on, obtain variables from Settings Script
		if (settingsOverride)
		{
			//Add component Override Script to keep this script less cluttered and re useable
			AudioMixerSettingsOverride settings = gameObject.AddComponent<AudioMixerSettingsOverride>();
			settings.SetAudioMixerController(this);
			settings.gameObject.SendMessage(overrideFunction, SendMessageOptions.DontRequireReceiver);
		}
	}

	void Update()
	{
		//When Enable Lerp is Activated
		if (lerpEnable)
		{
			float currentEnableValue = 0f;
			mixer.GetFloat(parameterName, out currentEnableValue);

			//Lerp to the enable value
			if (currentEnableValue < enableValue && lerpEnableSpeed > 0f ||
			        currentEnableValue > enableValue && lerpEnableSpeed < 0f)
			{
				mixer.SetFloat(parameterName, currentEnableValue + Time.deltaTime * lerpEnableSpeed);
			}
			else if (currentEnableValue >= enableValue && lerpEnableSpeed > 0f ||
			         currentEnableValue <= enableValue && lerpEnableSpeed < 0f)
			{
				lerpEnable = false;
			}
		}

		//When Disable Lerp is Activated
		if (lerpDisable)
		{
			//Lerp to the disable value
			float currentDisableValue = 0f;
			mixer.GetFloat(parameterName, out currentDisableValue);

			//Lerp to the enable value
			if (currentDisableValue < disableValue && lerpDisableSpeed > 0f ||
			        currentDisableValue > disableValue && lerpDisableSpeed < 0f)
			{
				mixer.SetFloat(parameterName, currentDisableValue + Time.deltaTime * lerpDisableSpeed);				
			}
			else if (currentDisableValue >= disableValue && lerpDisableSpeed > 0f ||
			         currentDisableValue <= disableValue && lerpDisableSpeed < 0f)
			{
				lerpDisable = false;
			}
		}
	}

	void OnEnable()
	{
		if (activateOnEnable)
		{
			ActivateLerp();
		}
	}

	void OnDisable()
	{
		if (activateOnDisable)
		{
			DeactivateLerp();
		}		
	}

	public void ActivateLerp()
	{
		if (!lerpWhenEnable)
		{
			ChangeFloat(enableValue);
		}
		else
		{
			//Lerp Float
			lerpEnable = true;
			lerpDisable = false;			
		}
	}

	public void DeactivateLerp()
	{
		if (!lerpWhenDisable)
		{
			ChangeFloat(disableValue);
		}
		else
		{
			if (lerpSendMessageObject)
			{
				lerpSendMessageObject.SendMessage(lerpMessage,
				                                  lerpDisableSpeed,
				                                  SendMessageOptions.DontRequireReceiver);				
			}
			else
			{
				//Lerp Float
				lerpDisable = true;
				lerpEnable = false;
			}
		}
	}


	public void ChangeFloat(float _value)
	{
		mixer.SetFloat(parameterName, _value);
	}
}
