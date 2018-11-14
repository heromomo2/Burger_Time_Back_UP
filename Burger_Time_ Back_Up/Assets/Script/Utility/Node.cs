using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private List<Node> m_LocalNode;

	public List<Node> GetLocalNode
	{
		get{return m_LocalNode;}
	}
	public int GetLocalNodeCount
	{
		get{return m_LocalNode.Count;}
	}
}
