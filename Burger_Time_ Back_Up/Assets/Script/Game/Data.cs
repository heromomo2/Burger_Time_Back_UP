using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Data : Singleton<Data> {
	private List<int> MyListOfPlayerScore = new List<int>();
	private List<string> MyListOfPlayerName = new List<string>();
	private string m_TempPlayerName;
	private int m_TempPlayerScore;
	private int m_PositionInLeaderboard;
	private int m_MaxSlot;
	// Use this for initialization
	void Start () 
	{
//		if (!PlayerPrefs.HasKey ("Leaderboard")) 
//		{
//			PlayerPrefs.SetString ("Leaderboard", "true");
//		} 
//		else 
//		{
//			Debug.LogWarning ("LeaderBoard is real");	
//		}
		m_MaxSlot = 7;
		SetPlayerNameAndScore (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public bool IsYourScoreHighEnough (int newScore) 
	{
		if (PlayerPrefs.HasKey ("Leaderboard")) 
		{
			for (int i = 0; i < m_MaxSlot; i++) 
			{	
				if (MyListOfPlayerScore[i] < newScore) 
				{   m_PositionInLeaderboard = i;
					m_TempPlayerScore = newScore;
					Debug.Log ("Your PositionInLeaderboard" + m_PositionInLeaderboard);
					return true;
				}
			}
		}
		return false;
	}


	public int GetTopHiscore () 
	{
		return MyListOfPlayerScore [0];
	}

	public int GetPositionInLeaderboard () 
	{
		return m_PositionInLeaderboard;
	}


	private void SortLeaderBoard (int Position) 
	{ // feed in the Position in where the player is going in the list4.
		if (PlayerPrefs.HasKey ("Leaderboard")) 
		{ //TODO: add the new player name& score in the list and bump down previous player below them in leaderboard;
			MyListOfPlayerScore.Insert(Position, m_TempPlayerScore);
			MyListOfPlayerName.Insert (Position, m_TempPlayerName);
			MyListOfPlayerName.RemoveRange (m_MaxSlot,MyListOfPlayerName.Count - m_MaxSlot );
			MyListOfPlayerScore.RemoveRange (m_MaxSlot, MyListOfPlayerScore.Count - m_MaxSlot);
		}
	}
		
	public string GetLeaderBoard(int Leaderboardnum) 
	{
		string result = " fail";

		if (PlayerPrefs.HasKey ("Leaderboard")&& Leaderboardnum < MyListOfPlayerName.Count) 
		{
			result =  MyListOfPlayerName [Leaderboardnum]+": "+ MyListOfPlayerScore [Leaderboardnum];
		} 
		return result;
//		else 
//		{
//			Debug.Log ("there is no leader data");
//		}

	}

	public void GetPlayername  (string newPlayer) 
	{
		m_TempPlayerName = newPlayer;
		Debug.Log ("PlayerName: "+m_TempPlayerName);
		SortLeaderBoard (m_PositionInLeaderboard); 
	}

	private void SetPlayerNameAndScore  () 
	{
		if (PlayerPrefs.HasKey ("Leaderboard")) 
		{
			for (int i = 0; i < m_MaxSlot; i++)
			{	
				MyListOfPlayerName.Add ("Player");
				MyListOfPlayerScore.Add(250);
			}
		}
	}
		


}
