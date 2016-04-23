using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioMixerSettingsOverride : MonoBehaviour
{
	private AudioMixerController audio;

	public bool destroyOnCompletion = true;

	public void SetAudioMixerController(AudioMixerController _audioMixerController)
	{
		audio = _audioMixerController;
	}
}
