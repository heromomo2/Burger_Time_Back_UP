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
	private string m_text = null;
	private string temp = "oops";
	private	string temp2= "oop77";
	private	float  timer=  3.0f;
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
			m_NewHiscoreText.text ="LeaderBoard";

			if (DidYouClearLevel) 
			{
				m_NewHiscoreText.color = Color.green;
			}

			for (int i = 0; i < 7; i++)
			{
				m_text = Data.Instance.GetLeaderBoard (i);
				//Debug.Log ("m_text :"+ m_text);
				//Debug.Log (" Leaderboardnum :"+ i);
				m_boardText [i].text = m_text;
				m_boardText [i].color = Color.white;
			}
		
			switch (Position)
			{
			case 1:
				//BlinkText ();
				m_boardText [0].color = Color.red;
//				temp = m_boardText [0].text;
//				BlinkText (, temp);
				break;
			case 2:
				m_boardText [1].color = Color.red;
//				temp = m_boardText [1].text;
//				BlinkText ();
//				m_boardText [1].text = temp2;
				break;
			case 3:
				m_boardText [2].color = Color.red;
//				temp = m_boardText [2].text;
//				BlinkText ();
//				m_boardText [2].text = temp2;
				break;
			case 4:
				m_boardText [3].color = Color.red;
//				temp = m_boardText [3].text;
//				BlinkText ();
//				m_boardText [3].text = temp2;
				break;
			case 5:
				m_boardText [4].color = Color.red;
//				temp = m_boardText [4].text;
//				BlinkText ();
//				m_boardText [4].text = temp2;
				break;
			case 6:
				m_boardText [5].color = Color.red;
//				temp = m_boardText [5].text;
//				BlinkText ();
//				m_boardText [5].text = temp2;
				break;
			case 7:
				m_boardText [6].color = Color.red;
//				temp = m_boardText [6].text;
//				BlinkText ();
//				m_boardText [6].text = temp2;
				break;
			default:
				Debug.Log (" error in the Gameover");
				break;
			}

		}
		else 
		{
			for (int i = 0; i < 7; i++) 
			{
				m_boardText [i].text = "";
				m_NewHiscoreText.text = "";
			}
			
		}

			
	}

//	private string mytimerflash (string content)
//	{
//		while(true){
//			timer -= Time.deltaTime;
//			return "";
//			if(timer >= 0)
//			{
//				timer = 0.5f;
//			
//			}
//			else
//			{
//			 return content ;
//			}
//		}
//		
//	}

	private IEnumerator BlinkText ( int i , string temp){
		//blink it forever. You can set a terminating condition depending upon your requirement
		while(true){
			//set the Text's text to blank
			m_boardText[i].text = "";
			//display blank text for 0.5 seconds
			yield return new WaitForSeconds(0.5f);
			//display “I AM FLASHING TEXT” for the next 0.5 seconds
			m_boardText[i].text = temp;
			yield return new WaitForSeconds(0.5f);
		}
	}
}
