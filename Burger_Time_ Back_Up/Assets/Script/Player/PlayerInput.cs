using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : Singleton<PlayerInput> 
{
	
	#region Properties
	public delegate void OnInputFire ();
	public event OnInputFire OnPressUp;
	public event OnInputFire OnPressDown;
	public event OnInputFire OnPressRight;
	public event OnInputFire OnPressLeft;
	public event OnInputFire OnPressPepper;
	public event OnInputFire OnPressPause;
	#endregion


	
	// Update is called once per frame
	void Update () 
	{
		GetInput ();
	}

	private void GetInput()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (OnPressLeft!= null)
			{
				OnPressLeft ();
			}
		} 

		if (Input.GetKeyDown(KeyCode.W))
		{
			if (OnPressUp != null)
			{
				OnPressUp ();
			}
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			if (OnPressDown != null)
			{
				OnPressDown ();
			}
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			if (OnPressRight != null)
			{
				OnPressRight ();
			}
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (OnPressPepper != null)
			{
				OnPressPepper ();
			}
		}

		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if (OnPressPause != null)
			{
				OnPressPause ();
			}
		}
	}
}
