using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : Singleton<MusicController> {

	#region Variables
	[SerializeField]
	private AudioSource m_MusicAudioSource; 
	[SerializeField]
	private List <AudioSource> m_AudioSource; 
	[SerializeField] private List <AudioClip> m_MusicAudioClip = new List<AudioClip>(); 
	[SerializeField] private List <AudioClip> m_SFXAudioClip = new List<AudioClip>(); 
	public bool m_IsPlaying;
	public int m_Index;
	#endregion

	void Start ()
	{
		SwitchMusicTrack (0);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			EndAudio ();
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			SwitchSFX (0,0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			SwitchSFX (1,0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			SwitchSFX (2,0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			SwitchSFX (5,1);
		}
	}

	public void PlayMusic()
	{
		if (m_MusicAudioSource != null && m_MusicAudioClip != null) 
		{	
			m_MusicAudioSource.Play ();
		}
	}

	public void PlaySFX(int SfxSource)
	{
		if (m_AudioSource[SfxSource] != null && m_SFXAudioClip != null) 
		{	
			m_AudioSource[SfxSource].Play ();
		}
	}

	public void SwitchMusicTrack(int Musicnum)
	{
		if (m_MusicAudioSource != null && m_MusicAudioClip != null)
		{	
			m_MusicAudioSource.clip = m_MusicAudioClip [Musicnum];
			PlayMusic ();
		}
	}

	public void SwitchSFX(int Sfxnum, int SfxSource)
	{
		if (m_AudioSource[SfxSource] != null && m_SFXAudioClip != null) 
		{
			m_AudioSource[SfxSource].clip = m_SFXAudioClip [Sfxnum];
			PlaySFX (SfxSource);
		}
	}

	public void EndAudio(){
		m_AudioSource[0].Stop ();
	}


}
