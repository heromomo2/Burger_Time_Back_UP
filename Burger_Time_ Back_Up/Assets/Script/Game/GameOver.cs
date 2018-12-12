using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class GameOver : MonoBehaviour {
	[SerializeField]
	private Text m_GameOverTitleText;
	[SerializeField]
	private Text m_NewHiscoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void GameOverPage(bool DidYouClearLevel, bool DidYouGetAHighScore , int Position )
	{
		if (DidYouClearLevel)
		{
			m_GameOverTitleText.text = "LeveL Clear!!!";
			m_GameOverTitleText.color = Color.green;
		} 
		else 
		{
			m_GameOverTitleText.text = "Game Over";
			m_GameOverTitleText.color = Color.blue;
		}

		if (DidYouGetAHighScore) 
		{
			if (DidYouClearLevel) 
			{
				m_NewHiscoreText.color = Color.green;
			}

			switch (Position) 
			{
			case 1:
				m_NewHiscoreText.text = "congratulations You're First place";
				break;
			case 2:
				m_NewHiscoreText.text = "congratulations You're Second place";
				break;
			case 3:
				m_NewHiscoreText.text = "congratulations You're Third place";
				break;
			case 4:
				m_NewHiscoreText.text = "congratulations You're Fourth place";
				break;
			case 5:
				m_NewHiscoreText.text = "congratulations You're Fifth place";
				break;
			case 6:
				m_NewHiscoreText.text = "congratulations You're Sixth place";
				break;
			case 7:
				m_NewHiscoreText.text = "congratulations You're Seventh place";
				break;
			default:
				print ("Incorrect Slot");
				break;
			}
		}
		else 
		{
			m_NewHiscoreText.text = "";
		}
		
	}
}
