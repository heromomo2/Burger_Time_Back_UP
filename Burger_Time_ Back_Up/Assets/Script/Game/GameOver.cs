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
	private	float  m_timer =  0.5f;
	private bool   m_isflash  = false;

	private Timer m_TImer;
	private int m_Index = 0;
	private Coroutine m_Coroutine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_TImer != null)
		{
			m_TImer.Update ();
	    }
	}

	void OnDestroy()
	{
		if (m_Coroutine != null) {
			m_Coroutine = null;
		}
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
				m_isflash = false;
			}
		
			switch (Position)
			{
			case 1:
				//BlinkText ();
				m_boardText [0].color = Color.red;
				//m_Coroutine = StartCoroutine(BlinkText (0));
				m_Index = 0;
				trueBlink ();
//				temp = m_boardText [0].text;
//				BlinkText (, temp);
				break;
			case 2:
				m_boardText [1].color = Color.red;
				m_Coroutine = StartCoroutine(BlinkText (1));
//				temp = m_boardText [1].text;
//				BlinkText ();
//				m_boardText [1].text = temp2;
				break;
			case 3:
				m_boardText [2].color = Color.red;
				m_Coroutine = StartCoroutine(BlinkText (2));
//				temp = m_boardText [2].text;
//				BlinkText ();
//				m_boardText [2].text = temp2;
				break;
			case 4:
				m_boardText [3].color = Color.red;
				m_Coroutine = StartCoroutine(BlinkText (3));
//				temp = m_boardText [3].text;
//				BlinkText ();
//				m_boardText [3].text = temp2;
				break;
			case 5:
				m_boardText [4].color = Color.red;
				m_Coroutine = StartCoroutine(BlinkText (4));
//				temp = m_boardText [4].text;
//				BlinkText ();
//				m_boardText [4].text = temp2;
				break;
			case 6:
				m_boardText [5].color = Color.red;
				m_Coroutine = StartCoroutine(BlinkText (5));
//				temp = m_boardText [5].text;
//				BlinkText ();
//				m_boardText [5].text = temp2;
				break;
			case 7:
				m_boardText [6].color = Color.red;
				m_Coroutine = StartCoroutine(BlinkText (6));
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
				m_NewHiscoreText.text = "You're score is too low";
			}
		}
			
	}

//	private Text mytimerflash (string content)
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
	private  void trueBlink ()
	{
		if (m_TImer == null) {

			m_TImer = new Timer (1);
			m_TImer.m_OnDone += trueBlink;

			m_boardText [m_Index].color = Color.red;
			m_isflash = false;
		} else {
//			Color tempcolor2 = new Color(0,0,0,0);
//			Color tempc//or1 = m_boardText[m_Index].color;
//			m_timer -= Time.deltaTime;
//			m_boardText [m_Index].color = tempcolor2;
//			if(m_timer > 0)
//			{
//				m_boardText [m_Index].color = tempcolor1;
//			}

			if(m_isflash)
			{
				m_boardText [m_Index].color = Color.red;
				m_isflash = false;
				m_TImer.Restart ();
			}
			else{
				m_boardText [m_Index].color = Color.clear;
				m_isflash = true;
				m_TImer.Restart ();
			}

			//m_TImer.Restart ();
		}





	}

	private IEnumerator BlinkText ( int i ){
		//blink it forever. You can set a terminating condition depending upon your requirement
		//while( true )
		{
			Color tempcolor2 = new Color(0,0,0,0);
			Color tempcolor1 = m_boardText[i].color;
			Debug.Log(" yes it's in the loop");
			//set the Text's text to blank
			if (m_isflash) 
			{
				m_boardText [i].color = tempcolor2;
				//display blank text for 0.5 seconds
				yield return new WaitForSeconds (0.5f);
				m_isflash = false;
			} 
			else
			{
//			//display “I AM FLASHING TEXT” for the next 0.5 seconds
				m_boardText [i].color = tempcolor1;
				yield return new WaitForSeconds (0.5f);
				m_isflash = true;
			}

			m_Coroutine = StartCoroutine (BlinkText(i));
		}
	}
}
