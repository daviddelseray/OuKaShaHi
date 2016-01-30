using UnityEngine;
using System.Collections;

public class ScriptCharacterControl : MonoBehaviour
{
    //Movement Members
    float m_MoveSpeedX;

    float m_MoveSpeedZ;

    public float m_MoveMultiplier;

    string m_MoveZ;

    string m_MoveX;
    //____________________________________________________________

    //Life Members

    public bool m_IsAlive;

    public float m_WaitBeforeRespawn;

    bool m_AlreadyDead;

    //___________________________________________________________

    //Others Members
    public int m_PlayerID;

    public GameObject go_Child;

    Rigidbody rb_ThisRigidBody;

    //____________________________________________________________

        
    

	// Use this for initialization
	void Start ()
    {
        m_MoveZ = "VerticalPlayer" + m_PlayerID;
        m_MoveX = "HorizontalPlayer" + m_PlayerID;
        rb_ThisRigidBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (m_PlayerID==1)
            m_IsAlive = false;
        }

        if(this.transform.position.y<= 0.5f * this.transform.localScale.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0.5f * this.transform.localScale.y, this.transform.position.z);
        }

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

        else
        {
            if (!m_AlreadyDead)
            {
                m_AlreadyDead = true;
                go_Child.SetActive(false);
                this.GetComponent<SphereCollider>().enabled = false;
                rb_ThisRigidBody.useGravity=false; 
                StartCoroutine(C_Respawn());
            }   
        }


    }

   

    IEnumerator C_Respawn ()
    {
        
        yield return new WaitForSeconds(m_WaitBeforeRespawn);
        go_Child.SetActive(true);
        this.GetComponent<SphereCollider>().enabled = true;
        rb_ThisRigidBody.useGravity = true;
        m_IsAlive = true;
        m_AlreadyDead = false;
    }

}
