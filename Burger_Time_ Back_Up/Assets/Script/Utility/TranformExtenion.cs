using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TranformExtenion : MonoBehaviour {

	[SerializeField]
	private Vector3 m_worldPositon;
	[SerializeField]
	private Vector3 m_worldRotation;
	[SerializeField]
	private Vector3 m_worldScale;
	void Update () 
	{
		m_worldPositon = transform.position;
		m_worldRotation = transform.rotation.eulerAngles;
		m_worldScale = transform.lossyScale;	
	}
}
