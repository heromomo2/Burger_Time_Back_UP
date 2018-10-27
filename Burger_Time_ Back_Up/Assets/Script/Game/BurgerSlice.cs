using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlice : MonoBehaviour {

	[SerializeField]
	private List<BurgerBit> m_BurgerSlice;
	private  Transform m_Target;
	[SerializeField]
	private  float m_Yaix = 2.0f;
	[SerializeField]
	private  float m_Speed = 1.0f;
	private  float m_step;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckABurgerBitAreTrue ();
		if (CheckAllBurgerBitAreTrue ()) 
		{
			Debug.Log(" all the bits have been step on");
			MoveBurgerSlice ();
		}
	    m_step = m_Speed * Time.deltaTime;
	}

	#region private fuctions
	private void PushBitdown ( BurgerBit m_bit) 
	{
		/*To do:  Move the bit little amont down after being step on,
		 * but don't send it down all the away*/ 

		Debug.Log("PushBitdown has been call");
	/*	m_Target.position = m_bit.transform.position + new Vector3(0.0f,2.0f,0.0f);
		if( m_Target.position != null)
		{
			m_bit.transform.position = Vector3.MoveTowards (m_bit.transform.position, m_Target.position, m_step);
		} */
	}
	private  bool CheckAllBurgerBitAreTrue()
	{
		foreach (BurgerBit elements in m_BurgerSlice )
		{
		  /* to do: check all the bits have been  step on. 
		   * then call the MoveBurgerSlice() */ 

			if (!elements.GetIsStepped) 
			{
				return false;
			}
		}
		return true;
	}


	private void CheckABurgerBitAreTrue()
	{
		foreach (BurgerBit elements in m_BurgerSlice )
		{
			if (elements.GetIsStepped) 
			{ // If a bit is Step on then all call th
				PushBitdown ( elements);
				Debug.Log(" One bits have been step on");
			}
		}
	}

	private void MoveBurgerSlice()
	{
		foreach (BurgerBit elements in m_BurgerSlice )
		{
			/* to do:  move the all the bits 
			 * down to next  platform.*/
			Debug.Log("MoveBurgerSlice has been call");
		}
	}
	#endregion
}
