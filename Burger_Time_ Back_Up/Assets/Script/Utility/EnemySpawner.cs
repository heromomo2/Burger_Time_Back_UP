using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	private GameObject m_EnemyPrefab = null;
	[SerializeField]
	private Transform m_Target = null;
	[SerializeField]
	private GameController  m_GameController;
	[SerializeField]
	 private Node m_StartNode = null;




	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*foreach (EnemyController enemy in m_EnemiesRemoveList)
		{
			// TO DO: remove any enemies have dea
			m_Enemies.Remove (enemy);
		}*/
//		if (Input.GetKey (KeyCode.Space)) 
//		{
//			SpawnEnemy ();
//		}
	}
	public EnemyController SpawnEnemy()
	{
		/*TODO: .Spawns an Enemy and  add it the list.*/
		GameObject temp = Instantiate<GameObject> (m_EnemyPrefab);
		temp.transform.position = this.transform.position;
		EnemyController TempEnemy = temp.GetComponent<EnemyController>();
		TempEnemy.StartNode (m_StartNode, m_Target );

//		Debug.Log(" SpawnEnemy is being calling");
		return TempEnemy;
	}

}
