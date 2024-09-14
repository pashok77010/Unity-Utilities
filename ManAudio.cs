using System;
using UnityEngine;
using UnityEngine.Audio;

public class ManAudio : MonoBehaviour
{
	public static ManAudio i;
	public AudioMixerSnapshot musicNormalSnapshot;
	public AudioMixerSnapshot musicMutedSnapshot;
	public AudioMixerSnapshot effectsNormalSnapshot;
	public AudioMixerSnapshot effectsMutedSnapshot;
	public AudioSource effectsAudioSource;
	public AudioClip tapClip;
	public float changeVolumDur = 0;

	void Awake()
	{
		i = this;
	}

	public void Play(AudioClip audioClip)
	{
		if (audioClip) effectsAudioSource.PlayOneShot(audioClip);
	}

	public void PlayTap()
	{
		// L.LW();
		if (tapClip) Play(tapClip);
	}

	public void EnableMusicAudio(bool enable)
	{
		if(enable)
		{
			musicNormalSnapshot.TransitionTo(changeVolumDur);
		}
		else
		{
			musicMutedSnapshot.TransitionTo(changeVolumDur);
		}
	}

	public void EnableEffectsAudio(bool enable)
	{
		if(enable)
		{
			effectsNormalSnapshot.TransitionTo(changeVolumDur);
		}
		else
		{
			effectsMutedSnapshot.TransitionTo(changeVolumDur);
		}
	}
}