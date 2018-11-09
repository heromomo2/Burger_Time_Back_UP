using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[SerializeField]
	private GameHUDController m_GameHudController;
	[SerializeField]
	private List<EnemySpawner> m_EnemySpawners;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

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



}
