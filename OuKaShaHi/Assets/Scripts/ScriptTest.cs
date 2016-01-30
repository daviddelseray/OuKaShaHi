using UnityEngine;
using System.Collections;

public class ScriptTest : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3 (this.transform.parent.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
}
