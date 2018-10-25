using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBit : MonoBehaviour {

	#region member variables
	private Transform m_Target;
	private bool m_IsStepped = false;
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
		{
			Pushdown ();
		}
	}
	#endregion

	#region private fuctions
	private void Pushdown () 
	{
		/*To do:  Move the bit little amont down after being step on,
		 * but don't send it down all the away*/ 
		//target =  target.ve
		m_IsStepped = true;
	}
	#endregion
}
