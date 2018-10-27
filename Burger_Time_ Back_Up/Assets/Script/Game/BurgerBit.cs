using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBit : MonoBehaviour {

	#region member variables
	private bool m_IsStepped = false;
	private bool m_IsOnPlate = false;
	#endregion


	#region Public fuctions
	public bool GetIsStepped
	{
		get{return m_IsStepped;}
	}
	public bool SetIsStepped
	{
		set {m_IsStepped = value;}
	}
	#endregion

	#region Collison
	void OnTriggerEnter2D(Collider2D Other)
	{
		if(Other.tag == "Player")
		{/* To check  if the bit is touching player*/
			m_IsStepped = true;
		//	Debug.Log("IsStepped:  true ");
		}
		if(Other.tag == "Plate")
		{ /* To check  if the bit is touching plate 
		at bottom of the level*/
			m_IsOnPlate = true;
		}

	}
	#endregion


}
