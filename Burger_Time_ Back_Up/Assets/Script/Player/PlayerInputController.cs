using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {
	#region
	[SerializeField] private MenuController m_MenuController;
	private bool  m_IsPepperused = false; 
	private bool  m_IsOnLadder = false;
	private bool  m_IsOnExistPoint = false; 
	private bool  m_IsOnTopPoint = false;
	[SerializeField] private int speed;
	#endregion

	#region Setter and getter
	public bool GetIsOnLadder
	{
		get {return m_IsOnLadder;}
	}
	public bool SetIsOnLadder
	{
		set { m_IsOnLadder = value;}
	}

	public bool GetIsOnExistPoint
	{
		get {return m_IsOnExistPoint;}
	}
	public bool SetIsOnExistPoint
	{
		set { m_IsOnExistPoint  = value;}
	}
	public bool SetIsOnTopPoint
	{
		set { m_IsOnTopPoint  = value;}
	}
	#endregion
	// Use this for initialization
	void Start () 
	{
		//Debug.Log (" Start is working");
		m_MenuController = m_MenuController.GetComponent<MenuController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput2 ();
		//Debug.Log (" Update is working");
	}

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


	private void GetInput2()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			//Debug.Log (" Akey was pressed");
			if (!m_IsOnLadder || m_IsOnExistPoint) 
			{
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			}
		} 
		if (Input.GetKeyDown(KeyCode.D))
		{
			//Debug.Log (" Dkey was pressed");
			if (!m_IsOnLadder|| m_IsOnExistPoint) 
			{
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			}
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			//Debug.Log (" Wkey was pressed");
			if(m_IsOnLadder&&!m_IsOnTopPoint )
			{
			transform.Translate(Vector3.up*speed *Time.deltaTime);
			}
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			//Debug.Log (" Skey was pressed");
			if (m_IsOnLadder) 
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
