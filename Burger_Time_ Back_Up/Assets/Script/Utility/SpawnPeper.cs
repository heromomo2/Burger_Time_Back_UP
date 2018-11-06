using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeper : MonoBehaviour {

	[SerializeField]
	private GameObject m_PepperPrefab;
//	[SerializeField]
//	private List<Vector3> m_Transform;
	private bool m_FaceUp= false;
	private bool m_FaceDown= false;
	private bool m_FaceRight= false;
	private bool m_FaceLeft= false;

	public void faceup()
	{
		m_FaceUp = true;
		m_FaceDown = false;
		m_FaceRight = false;
		m_FaceLeft = false;
	}
	public void facedown()
	{
		m_FaceUp = false;
		m_FaceDown = true;
		m_FaceRight = false;
		m_FaceLeft = false;
	}
	public void faceright()
	{
		m_FaceUp = false;
		m_FaceDown =  false;
		m_FaceRight = true;
		m_FaceLeft = false;
	}
	public void faceleft()
	{
		m_FaceUp = false;
		m_FaceDown =  false;
		m_FaceRight = false;
		m_FaceLeft = true;
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SpawnPepper () 
	{
		if (m_PepperPrefab != null /*&& m_Transform != null && m_Transform.Count > 3*/) {
			if (m_FaceUp) {
				GameObject Pepper = Instantiate<GameObject> (m_PepperPrefab);
				Pepper.transform.position = transform.position + (Vector3.up * 0.3f);
			}
			if (m_FaceDown) {
				GameObject Pepper = Instantiate<GameObject> (m_PepperPrefab);
				Pepper.transform.position = transform.position + (Vector3.down * 0.3f);
			}
			if (m_FaceRight) {
				GameObject Pepper = Instantiate<GameObject> (m_PepperPrefab);
				Pepper.transform.position = transform.position + (Vector3.right * 0.3f);
			}
			if (m_FaceLeft) {
				GameObject Pepper = Instantiate<GameObject> (m_PepperPrefab);
				Pepper.transform.position = transform.position + (Vector3.left * 0.3f);
			}
		}
	}
}
