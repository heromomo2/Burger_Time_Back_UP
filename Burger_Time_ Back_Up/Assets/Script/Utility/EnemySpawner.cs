﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	private GameObject m_EnemyPrefab = null;
	[SerializeField]
	private Transform m_Target = null;

	private List<EnemyController> m_Enemies = new List<EnemyController>(); // help keep track of enemies
	private List<EnemyController> m_EnemiesRemoveList = new List<EnemyController>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*foreach (EnemyController enemy in m_EnemiesRemoveList)
		{
			// TO DO: remove any enemies have dea
			m_Enemies.Remove (enemy);
		}*/
		
	}
	public void SpawnEnemy()
	{
		/* TODO: .Spawns an Enemy and  add it the list.*/
		/*GameObject temp = Instantiate<GameObject> (m_EnemyPrefab);
		temp.transform.parent = this.transform;
		temp.transform.localPosition = Vector3.zero;
		m_Enemies.Add (note);

		Debug.Log(" SpawnEnemy is being calling");*/
	}

	public void CheckifEnemyIsdead()
	{
	/*TODO: check Currently a list of Enemy for dead enemies. 
	 * Then remove them from the list and then call their destroy function.*/
	}
	public void DespawnAllEnemies()
	{
		/*TODO: Call the Destroy fuction in all  the Enemies. 
		 * This will be call in ResetGame fuction within GsmeControll . */
	}


}