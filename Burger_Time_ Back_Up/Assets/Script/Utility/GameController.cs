using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	[SerializeField]
	private GameHUDController m_GameHudController;
	[SerializeField]
	private List<EnemySpawner> m_EnemySpawners;
	[SerializeField]
	private List<EnemyController> m_Enemies = null;
	[SerializeField]
	private Transform  m_PlayerStartPoint;
	[SerializeField]
	private PlayerInputController m_Player;
	[SerializeField]
	private float m_EnemySpawnersTimer;
	private bool m_StopEnemySpawners;
	private int m_EnemyLimit = 4;
	private EnemyController m_TempEnemy;
	private Coroutine m_spawnCoroutine = null;

	/*public void AddEnemyToList (EnemyController  TempEnemy )
	{
		m_Enemies.Add (TempEnemy);
	}
	public void RemoveEnemyToList (EnemyController TempEnemy )
	{
		m_Enemies.Remove(TempEnemy);
	}*/
		
	// Use this for initialization
	void OnDestroy()
	{
		if (m_spawnCoroutine != null)
		{
			m_spawnCoroutine = null;
		}
	}
	void Start () 
	{
		m_spawnCoroutine = StartCoroutine (SpawnUpdate());
	}
	// Update is called once per frame
	void Update () 
	{
		
//		if (Input.GetKey(KeyCode.K))
//		{
//			PlayerBackToStart ();
//		}

		if (Input.GetKey (KeyCode.Space)) 
		{
			DespawnAllEnemy ();
			Debug.Log (" despawn all enemy");
		}

	}
		

	IEnumerator SpawnUpdate()
	{
		yield return new WaitForSeconds(m_EnemySpawnersTimer);
		if (m_Enemies.Count < m_EnemyLimit) 
		{
			m_Enemies.Add (m_EnemySpawners [Random.Range (0, m_EnemySpawners.Count)].SpawnEnemy ());
		}
		m_spawnCoroutine = StartCoroutine (SpawnUpdate());
	}
	private void DespawnAllEnemy()
	{
		foreach(EnemyController enemy in m_Enemies)
		{
			enemy.DestroyGameObject ();
			Debug.Log (" begone enemy");
		}
	}

	/*private void SetUpInput()
	{
		if(!PlayerInput.IsInstanceNull)
		{
			PlayerInput.Instance.OnPressUp += HitMoveUpKey;
			PlayerInput.Instance.OnPressDown += HitMoveDownKey;
			PlayerInput.Instance.OnPressRight += HitMoveRightKey;
			PlayerInput.Instance.OnPressLeft += HitMoveLeftKey;
			PlayerInput.Instance.OnPressPepper += HitPepperKey;
			PlayerInput.Instance.OnPressPause += HitPauseKey;
		}
	
	}

	private void OnDestroy()
	{
		if(!PlayerInput.IsInstanceNull)
		{
			PlayerInput.Instance.OnPressUp -= HitMoveUpKey;
			PlayerInput.Instance.OnPressDown -= HitMoveDownKey;
			PlayerInput.Instance.OnPressRight -= HitMoveRightKey;
			PlayerInput.Instance.OnPressLeft -= HitMoveLeftKey;
			PlayerInput.Instance.OnPressPepper -= HitPepperKey;
			PlayerInput.Instance.OnPressPause -= HitPauseKey;
		}

	}

	private void HitMoveUpKey()
	{
		Debug.Log ("HitMoveUpKey was pressed");	
	}
	private void HitMoveDownKey()
	{
		Debug.Log ("HitMoveDownKey was pressed");
	}
	private void HitMoveRightKey()
	{
		Debug.Log ("HitMoveRightKey was pressed");
	}
	private void HitMoveLeftKey()
	{
		Debug.Log ("HitMoveLeftKey was pressed");
	}
	private void HitPepperKey()
	{
		Debug.Log ("HitPepperKey was pressed");
	}
	private void HitPauseKey()
	{
		Debug.Log ("HitPauseKey was pressed");
		//m_MeunController
	}*/

	 private void PlayerBackToStart()
	{
		m_Player.transform.position = m_PlayerStartPoint.position;
		//m_Player.PlayerIsAlive;
	}

}
