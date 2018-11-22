using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : Singleton<MusicController> {

	#region Variables
	//[SerializeField]
	//private AudioSource m_MusicAudioSource,m_SFXAudioSource; 
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
			SwitchSFX (0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			SwitchSFX (1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			SwitchSFX (2);
		}
	}

	public void PlayMusic()
	{
		if (m_AudioSource[0] != null && m_MusicAudioClip != null) 
		{	
			m_AudioSource[0].Play ();
		}
	}

	public void PlaySFX()
	{
		if (m_AudioSource[1] != null && m_SFXAudioClip != null) 
		{	
			m_AudioSource[1].Play ();
		}
	}

	public void SwitchMusicTrack(int Musicnum)
	{
		if (m_AudioSource[0] != null && m_MusicAudioClip != null)
		{	
			m_AudioSource[0].clip = m_MusicAudioClip [Musicnum];
			PlayMusic ();
		}
	}

	public void SwitchSFX(int Sfxnum)
	{
		if (m_AudioSource[1] != null && m_SFXAudioClip != null) 
		{
			m_AudioSource[1].clip = m_SFXAudioClip [Sfxnum];
			PlaySFX ();
		}
	}

	public void EndAudio(){
		m_AudioSource[0].Stop ();
	}


}
