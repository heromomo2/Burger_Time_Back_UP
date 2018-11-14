using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private bool m_IsEnemyMoving = false;
	[SerializeField]
	private bool m_IsEnemyMovingOnLadder = false;
	[SerializeField]
	private bool m_IsEnemyMovingSide = false;
	[SerializeField]
	private bool m_IsEnemyMovingUP = false;
	[SerializeField]
	private bool m_IsEnemyMovingRight = false;
	[SerializeField]
	private Transform m_PlayerPosition;
	[SerializeField] 
	private float m_speed;
	[SerializeField]
	private float m_AmountTimeStun; 
	[SerializeField]
	private Node m_TargetNode;
	[SerializeField]
	private Node m_LastNode = null;
	[SerializeField]
	private bool m_isCrush;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("Time.delta time :"+ Time.deltaTime);
		//MoveEnemy ();

		EnemyAI ();
		/*If(m_IsTouchPepper)
		 * {
		 * m_IsEnemyMoving = false;
		 * StartCoroutine(EnemyisStunned())
		 * }
		 
		*/
	}

	private void EnemyAI()
	{
		/*TODO: find if the target node is blown you or you above and move in that direction. 
        *If the target node on the same platform as you move to the side it's on.
        */ 
		//  Debug.Log ("Enemy's position: " + transform.position);
		//	Debug.Log ("TargetNode's position: " + m_TargetNode.transform.position);

	  	float m_distanceBeteen = Vector3.Distance(m_TargetNode.transform.position, transform.position);
		if (transform.position != m_TargetNode.transform.position)
		{
			m_IsEnemyMoving = true;

			if (m_TargetNode.transform.position.y > transform.position.y) 
			{ 
				// go up
				m_IsEnemyMovingOnLadder = true; 
				m_IsEnemyMovingUP = true;
				m_IsEnemyMovingSide = false;
				m_IsEnemyMovingRight = false;
				Debug.Log ("enemy should going up" );
			}

			if (m_TargetNode.transform.position.y < transform.position.y) 
			{
				// go down
				m_IsEnemyMovingOnLadder = true; 
				m_IsEnemyMovingUP = false;
				m_IsEnemyMovingSide = false;
				m_IsEnemyMovingRight = false;
				Debug.Log ("enemy should going down" );
			}

			if (m_TargetNode.transform.position.x < transform.position.x)
			{
				// go left
				m_IsEnemyMovingOnLadder = false; 
				m_IsEnemyMovingUP = false;
				m_IsEnemyMovingSide = true;
				m_IsEnemyMovingRight = false;
			}

			if (m_TargetNode.transform.position.x >transform.position.x) 
			{
				// go right
				m_IsEnemyMovingOnLadder = false; 
				m_IsEnemyMovingUP = false;
				m_IsEnemyMovingSide = true;
				m_IsEnemyMovingRight = true;
			}

			MoveEnemy ();
		} 

		if(transform.position == m_TargetNode.transform.position) //|| m_distanceBeteen < 0.05)
		{
			m_IsEnemyMoving = false; // stop the enemy
			//Debug.Log ("Atta");
			//Debug.Log ("Enemy's position: " + transform.position);
			//Debug.Log ("TargetNode's position: " + m_TargetNode.transform.position);
			PickNewNode ();
			//m_TargetNode = m_TargetNode.GetLocalNode [Random.Range (0, m_TargetNode.GetLocalNodeCount)];
			m_IsEnemyMovingOnLadder = false; 
			m_IsEnemyMovingSide = false;
		}
	}

	private void PickNewNode()
	{
		//m_TargetNode = m_TargetNode.GetLocalNode [Random.Range (0, m_TargetNode.GetLocalNodeCount)];

		Node tempNode = null;
		foreach (Node node in m_TargetNode.GetLocalNode) 
		{
			/*  araay 1|6|7|8|3
			 * int lownum = array[0];
			 * for (int i = 1; i > arrray.lenght ; i++)
			 * {  
			 *    if( array[i] < lownum )
			 *     {
			 *      lownum = array[i];
			 *     }
			 * }
			*/
			if (node == m_LastNode) // ship element
			{
				continue;
			}
			if (tempNode == null) 
			{
				tempNode = node;
			} 
			else 
			{
				if( Vector3.Distance(node.transform.position, m_PlayerPosition.position) 
					< Vector3.Distance(tempNode.transform.position, m_PlayerPosition.position))
				{
					tempNode = node;
				}
			}
			//= Vector3.Distance (m_PlayerPosition ,);
		}
		m_LastNode = m_TargetNode;
		m_TargetNode = tempNode;
		//Debug.Log ("picking the next node");
	}

	// TODO: Move the Enemy  up and down or right or down.

	private void MoveEnemy()
	{   
		if (m_IsEnemyMoving) 
		{
			transform.position = Vector3.MoveTowards (transform.position, m_TargetNode.transform.position, m_speed);
//			if (m_IsEnemyMovingSide) 
//			{
//				if (m_IsEnemyMovingRight) 
//				{
//					// move right
//					transform.Translate (Vector3.right * m_speed * Time.deltaTime);
//				} 
//				else
//				{
//					// move left
//					transform.Translate (Vector3.left * m_speed * Time.deltaTime);
//				}
//			}
//
//			if (m_IsEnemyMovingOnLadder)
//			{
//				if (m_IsEnemyMovingUP) 
//				{
//					// move up
//					transform.Translate (Vector3.up * m_speed * Time.deltaTime);
//				} 
//				else 
//				{
//					// move down
//					transform.Translate (Vector3.down * m_speed * Time.deltaTime);
//				}
//			}
		}
	}

	/*IEnumerator Example()
	{
		yield return new WaitForSeconds(m_AmountTimeStun);
		m_IsTouchPepper reset

	}*/

}
