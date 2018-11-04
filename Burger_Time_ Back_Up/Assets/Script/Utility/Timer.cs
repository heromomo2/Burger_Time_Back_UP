using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	#region Variable and Properties
	//Public 
	public event System.Action m_OnDone;
	public event System.Action m_OnUpdate;

	//Private  
	private float  m_CurrentTime = 0.0f;
	private float  m_TotalTime = 0.0f;

	private bool m_IsStarted = false;
	private bool m_IsPaused = false;
	private bool m_IsDone = false;


	//Properties 
	public float RemainingTime {get {return m_TotalTime - m_CurrentTime;} }
	public float CurrentTime {get {return m_CurrentTime; } }
	public float Ratio {get{return m_CurrentTime / m_TotalTime; } }
	public bool IsDone { get { return m_IsDone; } }

	#endregion

	#region Public Methods
	public Timer (float time)
	{
		m_CurrentTime = 0.0f;
		m_TotalTime = time;
		m_IsPaused = false;
		m_IsStarted = false;
		m_IsDone = false;
	}

	public void Start()
	{
		m_IsStarted = true;
		m_IsPaused = false;
		m_IsDone = false;

	}
	public void Pause(bool isPaused)
	{
		m_IsPaused = isPaused;
	}

	public void Restart()
	{
		m_CurrentTime = 0.0f;
		m_IsPaused = false;
		m_IsStarted = true;
		m_IsDone = false;
	}
	public void Stop()
	{
		m_IsStarted = false;

	}

	public void Update()
	{
		if (m_IsStarted && !m_IsDone) 
		{
			if (!m_IsPaused) 
			{
				m_CurrentTime += Time.deltaTime;

				if (m_CurrentTime < m_TotalTime) 
				{

					if (m_OnUpdate != null) 
					{
						m_OnUpdate ();
					}

				} 
				else 
				{
					m_IsDone = true;

					if (m_OnDone != null) 
					{
						m_OnDone ();

					}
				}
			}
		}
	}
	#endregion
}
