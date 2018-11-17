using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private bool m_IsEnemyMoving = false;
//	[SerializeField]
//	private bool m_IsEnemyMovingOnLadder = false;
//	[SerializeField]
//	private bool m_IsEnemyMovingSide = false;
//	[SerializeField]
//	private bool m_IsEnemyMovingUP = false;
//	[SerializeField]
//	private bool m_IsEnemyMovingRight = false;
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
	private bool m_isCrush = false;

	[SerializeField]
	private EnemyCollision m_EnemyCollison;
	// Use this for initialization


	public void CrushTheEnemy()
	{
		m_isCrush =true;
	}
	public void StartNode(Node FirstNode , Transform PlayerPosition)
	{
		m_TargetNode = FirstNode;
		m_PlayerPosition = PlayerPosition;

	}
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log("Time.delta time :"+ Time.deltaTime);
		//MoveEnemy ();

//		EnemyAI ();
		/*If(m_IsTouchPepper)
		 * {
		 * m_IsEnemyMoving = false;
		 * StartCoroutine(EnemyisStunned())
		 * }
		 
		*/

		EnemyAI ();
	}

	private void EnemyAI()
	{
		/*TODO: find if the target node is blown you or you above and move in that direction. 
        *If the target node on the same platform as you move to the side it's on.
        */ 
		if (m_isCrush) 
		{
			DestroyGameObject ();
		}
		if (m_EnemyCollison.GetTouchPepper) 
		{
			m_IsEnemyMoving = false;
			StartCoroutine ( Stun());
		}
			
		if (m_IsEnemyMoving) 
		{
			// move to the node
			if (transform.position != m_TargetNode.transform.position) 
			{
				MoveEnemy ();
			}
			else if (transform.position == m_TargetNode.transform.position)
			{
			// when you are at the node.
				PickNewNode ();
			}
		}
	}

	private void PickNewNode()
	{
		//m_TargetNode = m_TargetNode.GetLocalNode [Random.Range (0, m_TargetNode.GetLocalNodeCount)];

		Node tempNode = null;
		foreach (Node node in m_TargetNode.GetLocalNode) 
		{
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
		}
		m_LastNode = m_TargetNode;
		m_TargetNode = tempNode;
		//Debug.Log ("picking the next node");
	}

	// TODO: Move the Enemy  up and down or right or down.

	private void MoveEnemy()
	{   
	 	transform.position = Vector3.MoveTowards (transform.position, m_TargetNode.transform.position, m_speed);		
	}

	IEnumerator Stun()
	{
		yield return new WaitForSeconds(m_AmountTimeStun);
		//reset
		m_EnemyCollison.ResetTouchPepper(); 
		m_IsEnemyMoving= true;
	}
	public void DestroyGameObject()
	{
		Destroy (gameObject);
	}
}
