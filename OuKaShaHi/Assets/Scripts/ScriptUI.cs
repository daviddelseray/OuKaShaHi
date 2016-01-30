using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptUI : MonoBehaviour
{
    public Text m_Announcer;
    public float m_DisplayTime;

	// Use this for initialization
	void Start ()
    {
        m_Announcer.enabled = false; 
	}
	
	public void LaunchDisplay (string Attack)
    {
        StartCoroutine(DisplayText(Attack));
    }

    IEnumerator DisplayText (string Attack)
    {
        m_Announcer.text = Attack;
        m_Announcer.enabled = true;
        yield return new WaitForSeconds(m_DisplayTime);
        m_Announcer.enabled = false; 
    }


}
