using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlice : MonoBehaviour {
	[SerializeField]
	private List<GameObject> m_TargetSpots;
	[SerializeField]
	private List<BurgerBit> m_BurgerSlice;
	[SerializeField]
	private  float m_Speed = 1.0f;
	private  float m_step;
	[SerializeField]
	private  int m_Index= 1;
	private  Vector3 m_Target;
	private  bool m_IsMoving = false;
	private  bool m_IsEmemyOnBurger = false;
	[SerializeField]
	private  bool m_IsAtPlate = false;
	private GameObject m_Enemies = null;
	private int temp = 0;


	
	public bool IsAtPlate
	{
		get{return m_IsAtPlate;}
	}
	public bool IsMoving
	{
		get{return m_IsMoving;}
	}

	// Use this for initialization
	void Start () 
	{   
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

					m_Target =m_TargetSpots[m_Index].transform.position;
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
		  /* TODO: Check all the bits have been step on. */ 

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
			if(m_Enemies != null && m_Enemies.transform.parent != this.transform)
			{
				m_Enemies.transform.parent = this.transform;
			}
			Debug.Log("is being called");
			if (transform.position == m_Target) 
			{/* If we are at our target position then set M_IsMoving to false.
              *Reset all the bits m_IsStepped to false and reverse the PushBitdown()function.*/
				m_Index = Mathf.Min (++m_Index, m_TargetSpots.Count - 1);
				//m_IsMoving = false;
				if (m_IsEmemyOnBurger) 
				{//* double drop
					temp = ++temp;
					if (temp > 1) 
					{
						m_IsEmemyOnBurger = false;
						temp = 0;
					}
				}

				m_IsMoving = false;
				if (!m_IsEmemyOnBurger) 
				{/*If a ememy  on a burgerslice keep failing  */
					foreach (BurgerBit elements in m_BurgerSlice) 
					{   //Retset
						elements.Reset ();
					}
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
			m_IsAtPlate = Other.GetComponent<BurgerSlice>().IsAtPlate;
		}
		if (Other.tag == "Enemy") 
		{ 
		//	Debug.Log (" The BurgerSlices touch the Enemy before falling ");
			/* If enemy touch BurgerSlice they will stick up to it.
			*/
			//Other.GetComponent<EnemyController>().CrushTheEnemy();
			// Top of a burger. Enemy on a slice whit about to fail.
			m_IsEmemyOnBurger = true;
			//m_Enemies = Other.gameObject;
			Debug.Log("beep beep enemy");


			// Bottom of a burger. about to be squish
		}
		if (Other.tag == "Plate") 
		{
			m_IsAtPlate = true;
			Debug.Log (" The BurgerSlices are touch are touching the plate.");
		}
	}
	void OnTriggerExit2D(Collider2D Other)
	{
		if (Other.tag == "Enemy"&& !CheckAllBurgerBitAreTrue()) 
		{ 
			//	Debug.Log (" The BurgerSlices touch the Enemy before falling ");
			 m_IsEmemyOnBurger = false;
		}
	}
		
}
