using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBit : MonoBehaviour {


	[SerializeField]
	private float m_DownFactor;
	#region member variables
	private bool m_IsStepped = false;
	//private bool m_IsOnPlate = false;
	#endregion

	#region Public fuctions
	public bool IsStepped
	{
		get{return m_IsStepped;}
	}
	public float DownFactor
	{
		get{return m_DownFactor;}
	}
	#endregion

	public void Reset()
	{
		m_IsStepped = false;
	 	//transform.localPosition = transform.localPosition + (Vector3.down * m_DownFactor);
		//Debug.Log("Reset");
	}
	#region Collison
	void OnTriggerEnter2D(Collider2D Other)
	{
		if(Other.tag == "Player"||Other.tag == "Burger")
		{/* To check  if the bit is touching player*/
			if (!m_IsStepped)
			{
				m_IsStepped = true;
					Debug.Log("IsStepped:  true ");
				//PushBitdown ();
			}
		}
		/*if(Other.tag == "Plate")
		{  To check  if the bit is touching plate 
		at bottom of the level
			m_IsOnPlate = true;
		}*/
	}
	#endregion

	private void PushBitdown () 
	{
		/*To do:  Move the bit little amont down after being step on,
		 * but don't send it down all the away*/ 
		//Debug.Log("PushBitdown has been call");
		transform.localPosition = transform.localPosition + (Vector3.up * m_DownFactor);
	}

}
