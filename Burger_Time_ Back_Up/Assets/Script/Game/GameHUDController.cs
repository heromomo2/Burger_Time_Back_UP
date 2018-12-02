using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameHUDController : MonoBehaviour {

	#region UI Objects
	[SerializeField]
	private List<GameObject> m_Icons;
	[SerializeField]
	private Text m_OneCupText;
	[SerializeField]
	private Text m_PepperText;
	[SerializeField]
	private Text m_HiscoreText;
	#endregion
	#region Varible of scoreboard
	private int m_NumOfOneCup = 0;
	private int m_NumOfPepper = 5;
	private int m_NumOflives = 4;
	private int m_NumOfHiscore = 413;
	#endregion



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		DisplayScoreBoard ();
	}


	public int GetNumofPeper
	{
		get{return m_NumOfPepper;}	
	}
	public int GetNumoflives
	{
		get{return m_NumOflives;}	
	}
	public int GetNumOfOneCup
	{
		get{return m_NumOfOneCup;}	
	}
	public void IncreaseScoreByMovingBurgerSlice()
	{
		m_NumOfOneCup += 15;	
	}
	public void IncreaseScoreByKillEnemies()
	{
		m_NumOfOneCup += 50;	
	}

	public void IncreaseScoreByCascade ()
	{
		m_NumOfOneCup += 100;	
	}
	public void DecreasePeppercount()
	{
		m_NumOfPepper -=1;	
	}
//	public void IncreasePeppercount()
//	{
//		m_NumOfPepper +=1;	
//	}
	public void DecreaseLives()
	{
		m_NumOflives -=1;
		LiveIconDecrease ();
	}
	public void SetHiscorenum( int TopHiscore)
	{
		m_NumOfHiscore = TopHiscore;
	}


	private void LiveIconDecrease()
	{
		switch (m_NumOflives)
		{
		case 0:
			for (int i = 0; i < 4; i++) 
			{
				m_Icons [i].SetActive (false);
			}
			break;
		case 1:
			for(int i = 0; i < 3; i++)
			{
				m_Icons [i].SetActive(false);
			}
			break;
		case 2:
			for(int i = 0; i < 2; i++)
			{
				m_Icons [i].SetActive(false);
			}
			break;
		case 3:
			for(int i = 0; i < 1; i++)
			{
				m_Icons [i].SetActive(false);
			}
			break;
		default:
			Debug.Log ("you pass the numlives");
			break;
		}
	}

	private void DisplayScoreBoard ()
	{
		m_PepperText.text ="Pepper:"+ m_NumOfPepper.ToString();
		m_OneCupText.text = "1Cup:" + m_NumOfOneCup.ToString();
		m_HiscoreText.text = "Hiscore: "+ m_NumOfHiscore;
		//LiveIconDecrease ();
	}


}
