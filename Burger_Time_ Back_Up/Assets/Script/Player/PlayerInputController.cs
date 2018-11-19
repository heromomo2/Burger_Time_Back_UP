using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {
	#region   Variables
	[SerializeField]
	private MenuController m_MenuController;
	[SerializeField]
	 private GameHUDController m_GameHudController;
	[SerializeField] 
	private SpawnPeper m_SpawnPeper;
	private bool  m_IsOnLadder = false;
	private bool  m_IsOnExistPoint = false; 
	private bool  m_IsOnTopPoint = false;
	private bool  m_IsOnBottomPoint = false;
	[SerializeField] 
	private bool  m_IsPlayerDead = false;
	[SerializeField] private float speed;
	#endregion

	#region Setter
	public bool SetIsOnLadder
	{
		set { m_IsOnLadder = value;}
	}
	public bool SetIsOnExistPoint
	{
		set { m_IsOnExistPoint  = value;}
	}
	public bool SetIsOnTopPoint
	{
		set { m_IsOnTopPoint  = value;}
	}
	public bool SetIsOnBottomPoint
	{
		set { m_IsOnBottomPoint  = value;}
	}
	public  void PlayerIsDead()
	{
		m_IsPlayerDead = true;
	}
	public  void PlayerIsAlive()
	{
		m_IsPlayerDead = false;
	}
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_MenuController = m_MenuController.GetComponent<MenuController>();
		//m_SpawnPeper = m_MenuController.GetComponent<SpawnPeper>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!m_IsPlayerDead) 
		{
			GetInput2 ();
		}
	}
	/* test pepper being pressed
	*/

	/* Player input is done here	*/

	private void GetInput2()
	{
		if (Input.GetKey(KeyCode.A))
		{
			//Debug.Log (" Akey was pressed");
			if (!m_IsOnLadder || m_IsOnExistPoint) 
			{
				transform.Translate (Vector3.left * speed * Time.deltaTime);
				m_SpawnPeper.faceleft ();
				// ok jhjhjhjhjhjhj
			}
		} 
		if (Input.GetKey(KeyCode.D))
		{
			//Debug.Log (" Dkey was pressed");
			if (!m_IsOnLadder|| m_IsOnExistPoint) 
			{
				transform.Translate (Vector3.right * speed * Time.deltaTime);
				m_SpawnPeper.faceright ();
			}
		}
		if (Input.GetKey(KeyCode.W))
		{
			//Debug.Log (" Wkey was pressed");
			if(m_IsOnLadder&&!m_IsOnTopPoint )
			{
			transform.Translate(Vector3.up*speed *Time.deltaTime);
				m_SpawnPeper.faceup();
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			//Debug.Log (" Skey was pressed");
			if (m_IsOnLadder&&!m_IsOnBottomPoint) 
			{
			transform.Translate (Vector3.down * speed * Time.deltaTime);
				m_SpawnPeper.facedown();
			}
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log (" Pkey was pressed");
			m_MenuController.OpenPauseMenu (); 
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (m_GameHudController.GetNumofPeper > 0)
			{
				Debug.LogWarning("Enter was pressed. Pepper have been throwd");
				m_SpawnPeper.SpawnPepper ();
				m_GameHudController.DecreasePeppercount ();
			}
		}
	}
}
