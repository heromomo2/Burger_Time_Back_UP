using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	[SerializeField] private PlayerInputController m_PlayerInputController;
	// Use this for initialization
	void Start () 
	{
		m_PlayerInputController = m_PlayerInputController.GetComponent<PlayerInputController>();
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerStay2D(Collider2D Other)
	{
		if(Other.tag == "Ladder")
		{
			Debug.Log ("You are on ladder");
			m_PlayerInputController.SetIsOnLadder = true;
		}
		if(Other.tag == "ExistPoint")
		{
			//Debug.Log ("You are on ExistPoint");
			m_PlayerInputController.SetIsOnExistPoint = true;
		}
		if(Other.tag == "TopPoint")
		{
			Debug.Log ("You are on TopPoint");
			m_PlayerInputController.SetIsOnTopPoint = true;
		}
	}
	void OnTriggerEnter2D(Collider2D Other)
	{
		if(Other.tag == "Ladder")
		{
			Debug.Log ("You are on ladder");
			m_PlayerInputController.SetIsOnLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D Other)
	{
		if(Other.tag == "Ladder")
		{
			Debug.Log ("You are off ladder");
			m_PlayerInputController.SetIsOnLadder = false;
		}
		if(Other.tag == "ExistPoint")
		{
			//Debug.Log ("You are on ExistPoint");
			m_PlayerInputController.SetIsOnExistPoint = false;
		}

		if(Other.tag == "TopPoint")
		{
			Debug.Log ("You are off TopPoint");
			m_PlayerInputController.SetIsOnTopPoint = true;
		}
	}
}
