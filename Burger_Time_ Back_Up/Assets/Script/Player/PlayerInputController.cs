using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {
	#region   Variables
	[SerializeField] private MenuController m_MenuController;
	private bool  m_IsPepperused = false; 
	private bool  m_IsOnLadder = false;
	private bool  m_IsOnExistPoint = false; 
	private bool  m_IsOnTopPoint = false;
	private bool  m_IsOnBottomPoint = false;
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
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_MenuController = m_MenuController.GetComponent<MenuController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput2 ();
	
	}
	/* test pepper being pressed
	*/
	void OnGUI()
	{
		if (!m_IsPepperused)
		{
		GUI.Label(new Rect(10, 350, 100, 20), "Peper haven't be used");
		}
		else
		{
		GUI.Label(new Rect(10, 350, 100, 20), "Peper haven be used");
		}
	}
	/* Player input is done here	*/

	private void GetInput2()
	{
		if (Input.GetKey(KeyCode.A))
		{
			//Debug.Log (" Akey was pressed");
			if (!m_IsOnLadder || m_IsOnExistPoint) 
			{
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			}
		} 
		if (Input.GetKey(KeyCode.D))
		{
			//Debug.Log (" Dkey was pressed");
			if (!m_IsOnLadder|| m_IsOnExistPoint) 
			{
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.W))
		{
			//Debug.Log (" Wkey was pressed");
			if(m_IsOnLadder&&!m_IsOnTopPoint )
			{
			transform.Translate(Vector3.up*speed *Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			//Debug.Log (" Skey was pressed");
			if (m_IsOnLadder&&!m_IsOnBottomPoint) 
			{
			transform.Translate (Vector3.down * speed * Time.deltaTime);
			}
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log (" Pkey was pressed");
			m_MenuController.OpenPauseMenu (); 
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log (" Enter was pressed");
			m_IsPepperused = true;
		}
	}
}
