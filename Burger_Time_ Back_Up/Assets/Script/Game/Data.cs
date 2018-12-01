using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Data : Singleton<Data> {
	private List<int> MyListOfPlayerScore;
	private List<string> MyListOfPlayerName;
	private string m_TempPlayerName;
	private int m_TempPlayerScore;
	private int m_PositionInLeaderboard;
	private int m_MaxSlot ;
	// Use this for initialization
	void Start () 
	{
		if (!PlayerPrefs.HasKey ("Leaderboard")) 
		{
			PlayerPrefs.SetString ("Leaderboard", "true");
			m_MaxSlot = 7;
			SetPlayerNameAndScore (); 
		} 
		else 
		{
			Debug.LogWarning ("LeaderBoard is real");	
		}
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
					Debug.Log ("Your PositionInLeaderboard" + m_PositionInLeaderboard);
					return true;
				}
			}
		}
		return false;
	}

	private void SortLeaderBoard (int Position) 
	{ // feed in the Position in where the player is going in the list4.
		if (PlayerPrefs.HasKey ("Leaderboard")) 
		{ //TODO: add the new player name& score in the list and bump down previous player below them in leaderboard;
			// score 
			for (int i = Position; i < m_MaxSlot; i++) 
			{	
				int tempS = MyListOfPlayerScore [i];
				string tempN = MyListOfPlayerName [i];
				if( i == Position)
				{
					MyListOfPlayerScore [i] = m_TempPlayerScore;
					MyListOfPlayerName [i] = m_TempPlayerName;
				}
				else
				{
					MyListOfPlayerScore [i] = tempS;
					MyListOfPlayerName  [i] = tempN;
			    }
			}
		}
	}
		
	public string  GetLeaderBoard(int Leaderboardnum) 
	{
		if (PlayerPrefs.HasKey ("Leaderboard")) {
			return MyListOfPlayerName [Leaderboardnum] + MyListOfPlayerScore [Leaderboardnum];
		} 
		else 
		{
			Debug.Log ("there is no leader data");
			return " no data";
		}
	
	}



	public void GetPlayername  (string newPlayer) 
	{
		m_TempPlayerName = newPlayer;
		Debug.Log ("PlayerName: "+m_TempPlayerName);
	}

	private void SetPlayerNameAndScore  () 
	{
		if (PlayerPrefs.HasKey ("Leaderboard")) 
		{
			for (int i = 0; i < PlayerPrefs.GetInt ("SlotNum"); i++)
			{	
				 MyListOfPlayerName [i] =  i+" PLayer : ";
				  MyListOfPlayerScore [i] = 0;
			}
		}
	}
		


}
