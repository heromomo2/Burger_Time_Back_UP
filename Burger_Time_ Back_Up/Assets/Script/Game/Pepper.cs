using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper : MonoBehaviour {
	[SerializeField]
	private float m_DespawnTime = 0;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (DespawnUpdate());
		MusicController.Instance.SwitchSFX (2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator DespawnUpdate()
	{
		yield return new WaitForSeconds(m_DespawnTime);
		DestroyGameObject ();
	}

	void DestroyGameObject()
	{
		Destroy (gameObject);
	}

}
