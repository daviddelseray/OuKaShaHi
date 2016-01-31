using UnityEngine;
using System.Collections;

public class ScriptSideCreature : MonoBehaviour
{
    public int m_PlayerProperty;

    public ScriptMeshArray s_VisuArray;

    MeshFilter m_Appearance;

    string m_Creature;

    public ScriptCharacterControl s_Player1;
    public ScriptCharacterControl s_Player2;
    public ScriptCharacterControl s_Player3;
    public ScriptCharacterControl s_Player4;

    Rigidbody rb_MyRigidBody;

    // Use this for initialization
    void Start ()
    {
        m_Creature = PlayerPrefs.GetString("m_Character" + m_PlayerProperty);

        m_Appearance = GetComponent<MeshFilter>();
        rb_MyRigidBody = this.GetComponent<Rigidbody>();

        switch (m_Creature)
        {
            case "Cochon":
                m_Appearance.mesh = s_VisuArray.a_MeshArray[0];
                break;

            case "Paresseux":
                m_Appearance.mesh = s_VisuArray.a_MeshArray[1];
                break;

            case "Mouton":
                m_Appearance.mesh = s_VisuArray.a_MeshArray[2];
                break;

            case "Canard":
                m_Appearance.mesh = s_VisuArray.a_MeshArray[3];
                break;
        }
	}

   
	
	public void GotoyourDeath ()
    {
        switch (m_PlayerProperty)
        {
            case 1:
                rb_MyRigidBody.AddForce(new Vector3(6f, 5f, -4f), ForceMode.Impulse);
            break;

            case 2:
                rb_MyRigidBody.AddForce(new Vector3(-6f, 5f, -4f) , ForceMode.Impulse);
                break;

            case 3:
                rb_MyRigidBody.AddForce(new Vector3(-6f, 5f, 4f), ForceMode.Impulse);
                break;

            case 4:
                rb_MyRigidBody.AddForce(new Vector3(6f, 5f, 4f), ForceMode.Impulse);
                break;
        }
       
    }

    void OnCollisionEnter (Collision Other)
    {
        if (Other.collider.tag == "ArenaFloor")
        {
            switch (m_PlayerProperty)
            {
                case 1:
                    s_Player1.GetComponent<ScriptCharacterControl>().Respawn(this.transform.position);
                    break;

                case 2:
                    s_Player2.GetComponent<ScriptCharacterControl>().Respawn(this.transform.position);
                    break;

                case 3:
                    s_Player3.GetComponent<ScriptCharacterControl>().Respawn(this.transform.position);
                    break;

                case 4:
                    s_Player4.GetComponent<ScriptCharacterControl>().Respawn(this.transform.position);
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
