using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	private bool m_IsTouchPepper = false;
	private bool m_IsTouchBurgerSlice = false;
	#region public fuctions
	public bool GetTouchPepper
	{
		get{return m_IsTouchPepper;}
	}
	public bool GetTouchBurgerSlice
	{
		get{return m_IsTouchBurgerSlice;}
	}
	public void ResetTouchBurgerSlice()
	{
		m_IsTouchBurgerSlice = false;
	}
	public void ResetTouchPepper()
	{
		m_IsTouchPepper = false;
	}
	#endregion
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerStay2D(Collider2D Other)
	{
		if(Other.tag == "BurgerPart")
		{
			m_IsTouchBurgerSlice = true;
		}
		if(Other.tag == "Pepper")
		{
			m_IsTouchPepper = true;
		}
	}



}
