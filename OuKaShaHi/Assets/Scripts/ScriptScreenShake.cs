using UnityEngine;
using System.Collections;

public class ScriptScreenShake : MonoBehaviour
{
    Vector3 v3_InitPosition;

    Vector3 v3_NewPosition;
    Vector3 v3_NewPosition2;

    float m_NewXPos;

    public float m_MinXPos;
    public float m_MaxXpos;

    public float m_Wait;
	// Use this for initialization
	void Start ()
    {
        v3_InitPosition = this.transform.position;
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShakeThat();
        }
    }
	
	public void ShakeThat()
    {
        StartCoroutine(C_Shake());
    }

    IEnumerator C_Shake()
    {
        m_NewXPos = Random.Range(m_MinXPos, m_MaxXpos);
       

        v3_NewPosition = new Vector3(m_NewXPos,0,0);
        v3_NewPosition2 = new Vector3(-m_NewXPos*2,0,0);

        for(int i =0;i<3;i++)
        {
            this.transform.position += v3_NewPosition;
            yield return new WaitForSeconds(m_Wait);
            Debug.Log(this.transform.position);
            this.transform.position += v3_NewPosition2;
            yield return new WaitForSeconds(m_Wait);
            Debug.Log(this.transform.position);
            this.transform.position = v3_InitPosition;
        }
        

    }
}
