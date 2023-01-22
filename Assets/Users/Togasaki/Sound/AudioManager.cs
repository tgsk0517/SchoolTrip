using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
	[SerializeField]
	private AudioSource bgmAudioSource;

	[SerializeField]
	private AudioSource seAudioSource;

	private List<AudioSource> subSESources = new List<AudioSource>();

	public float MasterVolume = 1;
	public float BGMVolume = 1;
	public float SEVolume = 1;

	[SerializeField] List<BGMSoundData> bgmSoundDatas;
	[SerializeField] List<SESoundData> seSoundDatas;

	protected override void Awake()
	{
		base.Awake();

		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
        //PlayBGM(BGMName.Main);
    }

	public void PlayBGM(BGMName bgm)
	{
		BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
		bgmAudioSource.clip = data.audioClip;
		bgmAudioSource.volume = data.volume * BGMVolume * MasterVolume;
		bgmAudioSource.Play();
	}


	public void PlaySE(SEName se)
	{
		SESoundData data = seSoundDatas.Find(data => data.se == se);

		seAudioSource.clip = data.audioClip;
		seAudioSource.volume = data.volume * SEVolume * MasterVolume;
		seAudioSource.PlayOneShot(seAudioSource.clip);


	}

	public void StopBGM()
	{
		bgmAudioSource.Stop();
	}

	public void StopSE()
	{
		seAudioSource.Stop();
	}

}

[System.Serializable]
public class BGMSoundData
{
	public BGMName bgm;
	public AudioClip audioClip;
	[Range(0, 1)]
	public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
	public SEName se;
	public AudioClip audioClip;
	[Range(0, 1)]
	public float volume = 1;
}


public enum SEName
{
	shutter,
}

public enum BGMName
{
	Main

}
