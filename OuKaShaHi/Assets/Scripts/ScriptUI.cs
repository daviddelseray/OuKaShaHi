using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptUI : MonoBehaviour
{
    public Text m_Announcer;

	// Use this for initialization
	void Start ()
    {
        m_Announcer.enabled = false; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DisplayText (string Attack)
    {
        m_Announcer.text = Attack;

    }
}
