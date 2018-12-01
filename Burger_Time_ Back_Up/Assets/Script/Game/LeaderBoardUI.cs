using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LeaderBoardUI : MonoBehaviour {
	[SerializeField]
	private List<Text>m_boardText;


	public void UpdateLeaderBoard ()
	{
		for (int i = 0; i < m_boardText.Count; i++) 
		{
			m_boardText [i].text = Data.Instance.GetLeaderBoard (i);
		}

	}
}
