using UnityEngine;
using System.Collections;

public class ScriptCharacterControl : MonoBehaviour
{
    float m_MoveSpeedX;
    float m_MoveSpeedZ;
    public float m_MoveMultiplier;
    public int m_PlayerID;

    string m_MoveZ;
    string m_MoveX;

    public bool m_IsAlive;
    

	// Use this for initialization
	void Start ()
    {
        m_MoveZ = "VerticalPlayer" + m_PlayerID;
        m_MoveX = "HorizontalPlayer" + m_PlayerID;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_IsAlive)
        {
            m_MoveSpeedZ = Input.GetAxis(m_MoveZ) * m_MoveMultiplier * Time.deltaTime;
            m_MoveSpeedX = Input.GetAxis(m_MoveX) * m_MoveMultiplier * Time.deltaTime;

            if (m_MoveSpeedZ != 0)
            {
                this.transform.position += new Vector3(0f, 0f, m_MoveSpeedZ);
            }

            if (m_MoveSpeedX != 0)
            {
                this.transform.position += new Vector3(m_MoveSpeedX, 0f, 0f);
            }

        }


    }
}
