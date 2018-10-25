using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlice : MonoBehaviour {

	[SerializeField]
	private List<BurgerBit> m_BurgerSlice;
	//private List<BurgerBit> m_BurgerSlice;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CheckAllBurgerBit()
	{
		foreach (BurgerBit elements in m_BurgerSlice )
		{
		  /* to do: check all the bits have been  step on. 
		   * then call the MoveBurgerSlice() */ 	
		}
	}

	private void MoveBurgerSlice()
	{

		foreach (BurgerBit elements in m_BurgerSlice )
		{
			/* to do:  move the all the bits 
			 * down to next  platform.*/
		}
	}
}
