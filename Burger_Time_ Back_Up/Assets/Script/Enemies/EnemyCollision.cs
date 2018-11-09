using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	[SerializeField]
	private GameHUDController m_GameHudController;
	private bool m_IsTouchPepper = false;
	///private bool m_IsEnem;
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

	void OnTriggerEnter2D(Collider2D Other)
	{
		if(Other.tag == "BurgerPart")
		{
			if (Other.GetComponent<BurgerSlice>().IsMoving == true)
			{
			m_IsTouchBurgerSlice = true;
			Debug.Log ("Enemy is touch burger slice");
				m_GameHudController.IncreaseScore();
			}
		}
		if(Other.tag == "Pepper")
		{
			m_IsTouchPepper = true;
		}
	}



}
