using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class GameOver : MonoBehaviour {
	[SerializeField]
	private Text m_GameOverTitleText;
	[SerializeField]
	private Text m_NewHiscoreText;
	[SerializeField]
	private List<Text>m_boardText = new List<Text>();
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
		}
			
	}
}
