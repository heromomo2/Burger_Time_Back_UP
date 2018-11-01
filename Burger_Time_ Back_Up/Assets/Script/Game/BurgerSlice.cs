using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlice : MonoBehaviour {
	[SerializeField]
	private List<GameObject> m_TargetSpots;
	[SerializeField]
	private GameObject m_TargetSpot;
	[SerializeField]
	private List<BurgerBit> m_BurgerSlice;
	[SerializeField]
	private  float m_Speed = 1.0f;
	private  float m_step;
	[SerializeField]
	private  int m_Index= 1;
	private  Vector3 m_originPositon; 
	private  Vector3 m_Target;
	private  bool m_IsMoving = false;
	[SerializeField]
	private  bool m_IsAtPlate = false;

	public Vector3 OriginPositon
	{
		get{return m_originPositon;}
	}
	public bool IsAtPlate
	{
		get{return m_IsAtPlate;}
	}

	// Use this for initialization
	void Start () 
	{    /*Save the position for the next slice from the start */
		m_originPositon = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!m_IsAtPlate) 
		{
			if (CheckAllBurgerBitAreTrue ()) 
			{
				//	Debug.Log(" all the bits have been step on");
				if (!m_IsMoving)
				{
					m_IsMoving = true;
					/* Target position will be a constant downward
				 * until we get the position of the next burger slice. */
					//m_Target = transform.position + Vector3.down;
					//m_Target = m_TargetSpot.transform.position;

					m_Target =m_TargetSpots[m_Index].transform.position;
						
					//	transform.localPosition = transform.localPosition + (Vector3.up * m_DownFactor);
				}
				/* Call the MoveBurgerSlice fuction to move all bits down */
				MoveBurgerSlice ();
			}
		}
	}
	#region private fuctions

	private  bool CheckAllBurgerBitAreTrue()
	{/* Check all the bits have been stepped on.
	  *If all bits have been stepped on then return true if one bit hasn't been stepped on then return false.*/
		foreach (BurgerBit elements in m_BurgerSlice )
		{
		  /* To Do: Check all the bits have been step on. */ 

			if (!elements.IsStepped) 
			{
				return false;
			}
		}
		return true;
	}

	private void MoveBurgerSlice()
	{
	/* To Do:  move the all the bits 
	* down to next  platform.*/
		m_step = m_Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, m_Target, m_step); ///  move the target

		if (m_IsMoving)
		{
			if(transform.position == m_Target)
			{/* If we are at our target position then set M_IsMoving to false.
              *Reset all the bits m_IsStepped to false and reverse the PushBitdown()function.*/
				//m_originPositon = transform.position;
				m_IsMoving = false;
				m_Index = Mathf.Min(++m_Index, m_TargetSpots.Count-1) ;
				foreach (BurgerBit elements in m_BurgerSlice) 
				{   //Retset
					elements.Reset ();
					//elements.transform.localPosition = elements.transform.localPosition + (Vector3.down * elements.DownFactor);
				}
			} 
		}
	}
	#endregion

	void OnTriggerEnter2D(Collider2D Other)
	{
		if (Other.tag == "BurgerPart" && CheckAllBurgerBitAreTrue()&& !m_IsAtPlate ) 
		{/* If two BurgerSlices are touching and all bits have been stepped on then 
		  * set our target to the same position as other slice origin-position.*/
			Debug.Log (" The BurgerSlices are touch ");
		     // 	m_Target = Other.GetComponent<BurgerSlice>().OriginPositon;
			 m_Target = m_TargetSpots[m_Index].transform.position;
			m_IsAtPlate = Other.GetComponent<BurgerSlice>().IsAtPlate;
		}
		if (Other.tag == "Plate") 
		{
			m_IsAtPlate = true;
			m_Index = m_TargetSpots.Count - 1;
			Debug.Log (" The BurgerSlices are touch are touching the plate.");
		}
	}
}
