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
	[SerializeField] private float m_speed;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveEnemy ();
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


}
