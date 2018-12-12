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
	private GameOver m_GameOverUI;
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
	private bool m_DidYouGotBounsPoint = false;

		
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
		m_GameHudController.SetHiscorenum (Data.Instance.GetTopHiscore());
		//m_MenuController.CloseNameMenu ();
	}

	// Update is called once per frame
	void Update () 
	{
		// Use to delete the all Enemies on screen. it's use testing purposes.
		if (Input.GetKey (KeyCode.Space)) 
		{
			DespawnAllEnemy ();
			Debug.Log (" despawn all enemy");
		}

		// Use to stop the all Enemies and Enemies spanwers. it's use testing purposes.
		if (Input.GetKey (KeyCode.B)) 
		{
			StopAllEnemy ();
		}

		// Check if the enemy is has be crush then delete from the screen. 
		DespawnCrushEnemy ();

		/*  What do to when the player is killed.
		 * -Place the player back to his StartPosition.
		 * -Stop enemies and Enemyspawners.
		 * -Remove all the enemies from screen.
		 * -Set the player back to alive
		 * - player lose alive.
		*/ 
		if (m_Player.IsPlayerDead && m_GameHudController.GetNumoflives >= 1) 
		{
			MusicController.Instance.SwitchSFX (4,1);
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
		//Check if burgerSlices have hit each other and giving points. 
		CascadeBurgerSlicesPoints();

		/*Check if burgerSlice have move one spot and  give the player some point */
		BurgerSlicesMovePoints ();

		// OutOflives,Lose
		if (m_GameHudController.GetNumoflives <= 0)
		{
			PlayerBackToStart ();
			StopAllEnemy ();
			DespawnAllEnemy ();
			if (!m_DidYouGotBounsPoint) 
			{
				m_GameHudController.IncreaseScoreByUnusedPeper ();
				m_DidYouGotBounsPoint = true;
			}
			Debug.Log ("game over");
			MusicController.Instance.EndAudio ();

			/* Check your score  if higher than previous highs scores.
			 * -Open up the NameCanvan if you have highscore. You input your name and send you to the leaderboard.
			 * If you don't have a
			*/ 
			if(Data.Instance.IsYourScoreHighEnough(m_GameHudController.GetNumOfOneCup))
			{ 
				Debug.Log ("your score is high enough ");

					m_MenuController.OpenNameMenu ();
				m_GameOverUI.GameOverPage (false, true, Data.Instance.GetPositionInLeaderboard());

				if(m_MenuController.IsGameOverCanvasOpen)
				{
					StartCoroutine (GameEndUpdate ());
				}

			}// you dead and don't get a high score 
			else
			{
				m_GameOverUI.GameOverPage (false, false, 10);
				m_MenuController.OpenGameOver ();
				StartCoroutine (GameEndUpdate ());
			}
	    }
		/*  The player has clear the level. The win condition.
		 * - sent player back to mainmenu unless then beat a high score
		 * - give the player bonus points  clear.
		*/
		if( AreAllBurgerSlicesTouchingPlate())
		{
			Debug.LogWarning (" AreAllBurgerSlicesTouchingPlate are  true");
			if (!m_YoubeatGame) 
			{ 
				PlayerBackToStart ();
				StopAllEnemy ();
				DespawnAllEnemy ();
				Debug.LogWarning ("You won the game.");
				if (!m_DidYouGotBounsPoint) 
				{
					m_GameHudController.IncreaseScoreByUnusedPeper ();
					m_DidYouGotBounsPoint = true;
				}
				MusicController.Instance.EndAudio ();
				MusicController.Instance.SwitchSFX (5, 1);
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
				MusicController.Instance.SwitchSFX(5 , 1);
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
				MusicController.Instance.SwitchSFX(5 , 1);
				MusicController.Instance.SwitchSFX(6, 2);

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
					MusicController.Instance.SwitchSFX(0 , 0);
					MusicController.Instance.SwitchSFX(5 , 1);
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
//			Debug.Log (" begone enemy");
		}
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
//			Debug.Log (" begone enemy");
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
