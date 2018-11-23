using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	[SerializeField]
	private PlayerInputController m_PlayerInputController;
	[SerializeField]
	private GameHUDController m_GameHudController;
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
		//	Debug.Log ("You are on ladder");
			m_PlayerInputController.SetIsOnLadder = true;
		}
		if(Other.tag == "ExistPoint")
		{
			//Debug.Log ("You are on ExistPoint");
			m_PlayerInputController.SetIsOnExistPoint = true;
		}
		if(Other.tag == "TopPoint")
		{
		//	Debug.Log ("You are on TopPoint");
			m_PlayerInputController.SetIsOnTopPoint = true;
		}
		if(Other.tag == "BottomPoint")
		{
		//	Debug.Log ("You are on BottomPoint");
			m_PlayerInputController.SetIsOnBottomPoint = true;
		}
		if(Other.tag == "BlockRight")
		{
				//Debug.Log ("You can't go right");
			m_PlayerInputController.CanntPlayerGoRight ();
		}
		if(Other.tag == "Blockleft")
		{
			Debug.Log ("You can't go left");
			m_PlayerInputController.CanntPlayerGoLeft ();
		}
	}
	void OnTriggerEnter2D(Collider2D Other)
	{
		if(Other.tag == "Ladder")
		{
		//	Debug.Log ("You are on ladder");
			m_PlayerInputController.SetIsOnLadder = true;
		}
		if(Other.tag == "Enemy")
		{
			if(Other.GetComponent<EnemyController>().IsTheEnemyStun() == false)
			{
			m_PlayerInputController.PlayerIsDead ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D Other)
	{
		if(Other.tag == "Ladder")
		{
		//	Debug.Log ("You are off ladder");
			m_PlayerInputController.SetIsOnLadder = false;
		}
		if(Other.tag == "ExistPoint")
		{
			//Debug.Log ("You are on ExistPoint");
			m_PlayerInputController.SetIsOnExistPoint = false;
		}

		if(Other.tag == "TopPoint")
		{
		//	Debug.Log ("You are off TopPoint");
			m_PlayerInputController.SetIsOnTopPoint = false;
		}
		if(Other.tag == "BottomPoint")
		{
		//	Debug.Log ("You are off BottomPoint");
			m_PlayerInputController.SetIsOnBottomPoint = false;
		}
		if(Other.tag == "BlockRight")
		{
			//Debug.Log ("You can go right");
			m_PlayerInputController.CanPlayerGoRight ();
		}
		if(Other.tag == "Blockleft")
		{
			//Debug.Log ("You can go left");
			m_PlayerInputController.CanPlayerGoLeft ();
		}
	}
}
