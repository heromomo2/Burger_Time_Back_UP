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
	private Vector3 m_TargetPosition;
	[SerializeField] 
	private float m_speed;
	[SerializeField]
	private float m_AmountTimeStun; 

	[SerializeField]
	private Node m_targetnode;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveEnemy ();
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
	}


	// TODO: Move the Enemy  up and down or right or down.

	private void MoveEnemy()
	{   

		if (m_IsEnemyMoving) 
		{
			if (m_IsEnemyMovingSide) 
			{
				if (m_IsEnemyMovingRight) 
				{
					// move right
					transform.Translate (Vector3.right * m_speed * Time.deltaTime);
				} 
				else
				{
					// move left
					transform.Translate (Vector3.left * m_speed * Time.deltaTime);
				}
			}
			if (m_IsEnemyMovingOnLadder)
			{
				if (m_IsEnemyMovingUP) 
				{
					// move up
					transform.Translate (Vector3.up * m_speed * Time.deltaTime);
				} 
				else 
				{
					// move down
					transform.Translate (Vector3.down * m_speed * Time.deltaTime);
				}
			}
		}
	}

	/*IEnumerator Example()
	{
		yield return new WaitForSeconds(m_AmountTimeStun);
		m_IsTouchPepper reset

	}*/

}
