using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	#region  Variable for Canvas
	[SerializeField] private Canvas m_MainMeunCanvas;
	[SerializeField] private Canvas m_LeaderBoardCanvas;
	[SerializeField] private Canvas m_PauseCanvas;
	[SerializeField] private GameObject m_NameCanvas;
	[SerializeField] private Canvas m_GameOverCanvas;
	                 private string m_PlayerName;
	[SerializeField] private GameController m_GameController;
	[SerializeField] private LeaderBoardUI m_LeaderBoardUI;
	private bool m_IsNameCanvasOpen = false;
	private bool m_IsGameOverCanvasOpen = false;


	public bool IsNameCanvasOpen
	{
		get{ return m_IsNameCanvasOpen;}
	}

	public bool IsGameOverCanvasOpen 
	{
		get{ return m_IsGameOverCanvasOpen ;}
	}

	#endregion
	#region Public Funtio
	public void OpenMainMenu()
	{
		if (m_MainMeunCanvas != null && m_LeaderBoardCanvas  != null)
		{ 
			m_LeaderBoardCanvas.enabled = false;
			m_MainMeunCanvas.enabled = true;
			//Debug.Log (" you pass");
			MusicController.Instance.SwitchMusicTrack (0);
		}
	}

	public void OpenLeaderBoardMenu()
	{
		if (m_MainMeunCanvas != null && m_LeaderBoardCanvas != null && m_LeaderBoardUI != null )   
		{ 
		m_LeaderBoardCanvas.enabled = true;
		m_MainMeunCanvas.enabled = false;
			Debug.Log (" you pass");
			MusicController.Instance.EndAudio ();
			MusicController.Instance.SwitchMusicTrack (1);
			m_LeaderBoardUI.UpdateLeaderBoard ();
		}
	}

	public void ClosePauseMenu()
	{
		if (m_PauseCanvas != null && m_GameController !=null)   
		{ 
			m_PauseCanvas.enabled = false;	
			Debug.Log (" You Close PauseMenu");	
			Time.timeScale = 1;
			MusicController.Instance.EndAudio ();
			m_GameController.UnPauseAllEnemies ();
			MusicController.Instance.SwitchMusicTrack (3);
		}
	}

	public void OpenPauseMenu()
	{
		if (m_PauseCanvas != null  && m_GameController !=null )   
		{ 
			m_PauseCanvas.enabled = true;	
		  Debug.Log (" You Open PauseMenu");
			Time.timeScale = 0;
			MusicController.Instance.EndAudio ();
			MusicController.Instance.SwitchMusicTrack (2);
			m_GameController.PauseAllEnemies ();
		}
	}

	public void Quit()
	{
		Application.Quit ();
		UnityEditor.EditorApplication.isPlaying = false;     
	}

	public void LoadA( string scenename)
	{
		Debug.Log ("sceneName to load:" + scenename);
		SceneManager.LoadScene (scenename);
		Time.timeScale = 1;
		MusicController.Instance.EndAudio ();
		if (scenename == "GameMode") 
		{
			//MusicController.Instance.SwitchMusicTrack (2);
		}
		else 
		{
			MusicController.Instance.SwitchMusicTrack (0);
		}
	}
		
	public void OpenNameMenu()
	{
		if (m_NameCanvas != null)   
		{ 
			m_NameCanvas.SetActive (true);
			Debug.Log (" You Open NameMenu");
			//m_IsNameCanvasOpen = true;
		}
	}

	public void  CloseNameMenu()
	{
		if (m_NameCanvas != null)   
		{ 
			InputField m_InputField = m_NameCanvas.GetComponentInChildren<InputField> ();
			if (m_InputField.text != null)
			{
				m_PlayerName = m_InputField.text;
				Data.Instance.GetPlayername (m_PlayerName);
				m_NameCanvas.SetActive (false);
				Debug.Log (" You close NameMenu");
				//m_IsNameCanvasOpen = false;
				OpenGameOver();
			} 
			else 
			{
				Debug.Log ("You don't have a m_InputField in NameCanvas");
			}
		}
	}

	public void OpenGameOver()
	{
		if (m_GameOverCanvas != null)   
		{ 
			m_GameOverCanvas.enabled = true;	
			Debug.Log (" You open GameOver");
			m_IsGameOverCanvasOpen = true;
		}
	}

	public void CloseGameOver()
	{
		if (m_GameOverCanvas != null)   
		{ 
			m_GameOverCanvas.enabled = false;
			Debug.Log (" You close GameOver");
		}
	}
	#endregion

}
