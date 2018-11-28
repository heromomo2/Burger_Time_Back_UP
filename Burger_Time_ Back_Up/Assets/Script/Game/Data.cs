using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Data : Singleton<MusicController> 
{
	private List<int> MyListOfPlayerScore;
	private List<string> MyListOfPlayerName;
	private string m_TempPlayerName;
	private string m_TempPlayerScore;
	// Use this for initialization
	void Start () 
	{
		if (!PlayerPrefs.HasKey ("Leaderboard")) 
		{
			PlayerPrefs.SetString ("Leaderboard", "true");
			PlayerPrefs.SetInt ("SlotNum", 7);
			SetPlayername ();
			SetPlayerScore ();
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

	public bool CompareScore (int newScore) 
	{
		if (PlayerPrefs.HasKey ("Leaderboard")) 
		{
			for (int i = 0; i < PlayerPrefs.GetInt ("SlotNum"); i++) 
			{	
				if (PlayerPrefs.GetInt ("MyListOfPlayerScore_" + i, MyListOfPlayerScore [i]) < newScore) 
				{   
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
			for (int i = Position; i < PlayerPrefs.GetInt ("SlotNum"); i++) 
			{	
				int tempS = PlayerPrefs.GetInt("MyListOfPlayerScore_" + i);
				int tempN = PlayerPrefs.GetString("MyListOfPlayerName_" + i);
				if( i == Position)
				{
					PlayerPrefs.SetInt ("MyListOfPlayerScore_" + i, m_TempPlayerScore);
					PlayerPrefs.SetString ("MyListOfPlayerName_" + i, m_TempPlayerName);
				}
				else
				{
					PlayerPrefs.SetInt ("MyListOfPlayerScore_" + i, tempS);
					PlayerPrefs.SetString ("MyListOfPlayerName_" + i, tempN);
			    }
			}
		}
	}




//	private void GetPlayername  (string newPlayer) 
//	{
//		m_TempPlayerName = newPlayer;
//	}

	private void SetPlayername  () 
	{
		for (int i = 0; i < PlayerPrefs.GetInt("SlotNum"); i++) 
		{	
			PlayerPrefs.SetString ("MyListOfPlayerName_" + i, MyListOfPlayerName [i]);
		}
	}

	private void SetPlayerScore  () 
	{
		for (int i = 0; i < PlayerPrefs.GetInt("SlotNum"); i++) 
		{	
			PlayerPrefs.SetInt ("MyListOfPlayerScore_" + i, MyListOfPlayerScore [i]);
		}

	}
//	private Text GetPlayerScoreAndName  (Text slot ) 
//	{
//		for (int i = 0; i < MyListOfPlayerScore.Count; i++) 
//		{	
//			slot.text =	PlayerPrefs.SetString ("MyListOfPlayerName_" + i, MyListOfPlayerName [i]);
////				+ PlayerPrefs.SetInt ("MyListOfPlayerScore_" + i, MyListOfPlayerScore [i]) ;
//		}
//
//	}

}
