using UnityEngine;
using System.Collections;

public class ScriptCharacterVisual : MonoBehaviour
{
    string m_Beast;
    int m_PlayerID;
    MeshFilter m_BeastVisu;

	// Use this for initialization
	void Start ()
    {
        m_PlayerID = this.transform.parent.GetComponent<ScriptCharacterControl>().m_PlayerID;

        m_Beast = PlayerPrefs.GetString("m_Character" + m_PlayerID);
        Debug.Log(m_Beast);

        m_BeastVisu = this.GetComponent<MeshFilter>();
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
