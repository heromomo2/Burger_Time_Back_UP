using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlice : MonoBehaviour {

	[SerializeField]
	private List<BurgerBit> m_BurgerSlice;
	[SerializeField]
	private  float m_Speed = 1.0f;
	private  float m_step;
	private  Vector3 m_originPositon; 
	private  Vector3 m_Target;
	private  bool m_IsMoving = false;

	public Vector3 OriginPositon
	{
		get{return m_originPositon;}
	}

	// Use this for initialization
	void Start () {
		m_originPositon = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CheckAllBurgerBitAreTrue ()) 
		{
		//	Debug.Log(" all the bits have been step on");
			if(!m_IsMoving)
			{
				m_IsMoving = true;
				m_Target = transform.position + Vector3.down;
				//transform.localPosition = transform.localPosition + (Vector3.up * m_DownFactor);
			}
			MoveBurgerSlice ();
		}
	}

	#region private fuctions

	private  bool CheckAllBurgerBitAreTrue()
	{
		foreach (BurgerBit elements in m_BurgerSlice )
		{
		  /* to do: check all the bits have been  step on. 
		   * then call the MoveBurgerSlice() */ 

			if (!elements.IsStepped) 
			{
				return false;
			}
		}
		return true;
	}

	private void MoveBurgerSlice()
	{
	/* to do:  move the all the bits 
	* down to next  platform.*/
		m_step = m_Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, m_Target, m_step);
		//retset
		if (m_IsMoving)
		{
			if(transform.position == m_Target)
			{
				m_IsMoving = false;
				foreach (BurgerBit elements in m_BurgerSlice) 
				{
					elements.Reset ();
					//elements.transform.localPosition = elements.transform.localPosition + (Vector3.down * elements.DownFactor);
				}
			} 
		}
	}
	#endregion

	void OnTriggerEnter2D(Collider2D Other)
	{
		if (Other.tag == "BurgerPart" && CheckAllBurgerBitAreTrue() ) 
		{
			//Debug.Log ("BurgerPart!!!!!!!!");

			m_Target = Other.GetComponent<BurgerSlice>().OriginPositon;

		}
	}
}
