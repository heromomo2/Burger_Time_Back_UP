using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LeaderBoardUI : MonoBehaviour {
	[SerializeField]
	private List<Text>m_boardText = new List<Text>();
	private  string m_text = null;

	public void UpdateLeaderBoard ()
	{
		for (int i = 0; i < 7; i++) 
		{
			m_text = Data.Instance.GetLeaderBoard (i);
			Debug.Log ("m_text :"+ m_text);
			Debug.Log (" Leaderboardnum :"+ i);
			m_boardText [i].text = m_text;
		}

	}
}
