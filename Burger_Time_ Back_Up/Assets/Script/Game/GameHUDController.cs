using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameHUDController : MonoBehaviour {

	#region UI Objects
	[SerializeField]
	private List<Image> m_Icons;
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
	public void IncreaseScore()
	{
		m_NumOfOneCup += 50;	
	}
	public void DecreasePeppercount()
	{
		m_NumOfPepper -=1;	
	}
	public void IncreasePeppercount()
	{
		m_NumOfPepper +=1;	
	}
	public void IncreaseLives()
	{
		m_NumOflives -=1;	
	}

	private void DisplayScoreBoard ()
	{
		m_PepperText.text ="Pepper:"+ m_NumOfPepper.ToString();
		m_OneCupText.text = "1Cup:" + m_NumOfOneCup.ToString();
		m_HiscoreText.text = "Hiscore: nohiscore";
	}

}
