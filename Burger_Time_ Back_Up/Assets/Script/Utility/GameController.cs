using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	[SerializeField]
	private GameHUDController m_GameHudController;
	[SerializeField]
	private MenuController m_MenuController;
	[SerializeField]
	private List<EnemySpawner> m_EnemySpawners;
	[SerializeField]
	private List<BurgerSlice> m_BurgerSlice;
	[SerializeField]
	private List<EnemyController> m_Enemies = null;
	[SerializeField]
	private Transform  m_PlayerStartPoint;
	[SerializeField]
	private PlayerInputController m_Player;
	[SerializeField]
	private float m_EnemySpawnersTimer;
	[SerializeField]
	private float m_deathTimer;
	private bool m_StopEnemySpawners = false;
	[SerializeField]
	private int m_EnemyLimit = 4;
	private EnemyController m_TempEnemy;
	private Coroutine m_spawnCoroutine = null;
	private bool m_YoubeatGame = false;

		
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
		PlayerBackToStart ();
		MusicController.Instance.SwitchMusicTrack (3);
		m_MenuController.CloseGameOver ();
		m_MenuController.CloseNameMenu ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			DespawnAllEnemy ();
			Debug.Log (" despawn all enemy");
		}

		if (Input.GetKey (KeyCode.B)) 
		{
			StopAllEnemy ();
		}

		DespawnCrushEnemy ();

		if (m_Player.IsPlayerDead && m_GameHudController.GetNumoflives >= 1) 
		{
			MusicController.Instance.SwitchSFX (4);
			//m_GameHudController.DecreaseLives ();
			PlayerBackToStart ();
			StopAllEnemy ();
			DespawnAllEnemy ();
			m_StopEnemySpawners = true;
			m_Player.PlayerIsAlive ();
			m_StopEnemySpawners = false;
			m_GameHudController.DecreaseLives ();
			//StartCoroutine (ReturnByDeathUpdate());
		}

		CascadeBurgerSlicesPoints();
		//BurgerSlicesMovePoints ();

		if (m_GameHudController.GetNumoflives <= 0)
		{
			PlayerBackToStart ();
			StopAllEnemy ();
			DespawnAllEnemy ();
			Debug.Log ("game over");
			MusicController.Instance.EndAudio ();
			m_MenuController.OpenNameMenu ();
			if (m_MenuController.CloseNameMenu ()) 
			{
				m_MenuController.OpenGameOver ();
				StartCoroutine (GameEndUpdate ());
			}
	    }
		if( AreAllBurgerSlicesTouchingPlate())
		{
			Debug.LogWarning (" AreAllBurgerSlicesTouchingPlate are  true");
			if (!m_YoubeatGame) 
			{ 
				PlayerBackToStart ();
				StopAllEnemy ();
				DespawnAllEnemy ();
				Debug.Log ("You won");
				MusicController.Instance.EndAudio ();
				MusicController.Instance.SwitchSFX (4);
				m_YoubeatGame = true;
			}
		}
	}


	IEnumerator GameEndUpdate()
	{
		yield return new WaitForSeconds(5);
		m_MenuController.LoadA("StartMode");
	}

	IEnumerator SpawnUpdate()
	{
		yield return new WaitForSeconds(m_EnemySpawnersTimer);
		if (m_Enemies.Count < m_EnemyLimit&& !m_StopEnemySpawners ) 
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
		m_Enemies.Clear ();
	}
	private void CascadeBurgerSlicesPoints()
	{
		foreach(BurgerSlice burgerslice in m_BurgerSlice)
		{
			if (burgerslice.IsBurgerSliceCascade) 
			{
				m_GameHudController.IncreaseScoreByCascade ();
				burgerslice.BurgerSliceIsNotCascade();
			}
		}
	}
	private void BurgerSlicesMovePoints()
	{
		foreach(BurgerSlice burgerslice in m_BurgerSlice)
		{
			if (burgerslice.IsBurgerSliceMovePoints) 
			{
				m_GameHudController.IncreaseScoreByMovingBurgerSlice ();
				burgerslice.BurgerSliceIsntMovePoints ();     
			}
		}
	}

	private void DespawnCrushEnemy()
	{
		if (m_Enemies != null) 
		{
			EnemyController tempEnemy = null;
			int NumofEnemies = m_Enemies.Count;
			for (int i = 0; i < NumofEnemies; i++) 
			{
				NumofEnemies = m_Enemies.Count;
				if (m_Enemies [i].IsTheEnemyCrush ()) 
				{
					tempEnemy = m_Enemies [i];
					m_Enemies.Remove (tempEnemy);
					tempEnemy.DestroyGameObject ();
					Debug.Log (" enemy was crush rip");
					//i = 0;
					NumofEnemies = m_Enemies.Count;
					m_GameHudController.IncreaseScoreByKillEnemies ();
					MusicController.Instance.SwitchSFX(0);
				}
			} 
		}
	}
	private void StopAllEnemy()
	{
		m_StopEnemySpawners = true;// stop all the spawners
		foreach(EnemyController enemy in m_Enemies)
		{
			enemy.StopEnemyMovement();
			Debug.Log (" begone enemy");
		}
	}

	private void GameOver()
	{


	}
	private bool AreAllBurgerSlicesTouchingPlate()
	{
		foreach(BurgerSlice burgerslice in m_BurgerSlice)
		{
			if (!burgerslice.IsAtPlate) 
			{
				return false;
			}
		}
		return true;
	}
	private void AllEnemiesCanMove()
	{
		m_StopEnemySpawners = false;// start up all the spawners
		foreach(EnemyController enemy in m_Enemies)
		{
			enemy.LetEnemyMovement ();
			Debug.Log (" begone enemy");
		}
	}
	public void PauseAllEnemies ()
	{
		StopAllEnemy ();
	}
	public void UnPauseAllEnemies ()
	{
		AllEnemiesCanMove ();
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
	}

}
