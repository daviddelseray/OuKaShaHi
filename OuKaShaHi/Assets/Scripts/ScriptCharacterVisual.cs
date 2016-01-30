using UnityEngine;
using System.Collections;

public class ScriptCharacterVisual : MonoBehaviour
{
    public string m_Beast;
    int m_PlayerID;
    MeshFilter m_BeastVisu;

    public ScriptMeshArray s_VisuArray;

	// Use this for initialization
	void Start ()
    {
        m_PlayerID = this.transform.parent.GetComponent<ScriptCharacterControl>().m_PlayerID;

        m_Beast = PlayerPrefs.GetString("m_Character" + m_PlayerID);
        

        m_BeastVisu = this.GetComponent<MeshFilter>();

        switch (m_Beast)
        {
            case "Cochon":
                m_BeastVisu.mesh = s_VisuArray.a_MeshArray[0];
                break;

            case "Paresseux":
                m_BeastVisu.mesh = s_VisuArray.a_MeshArray[1];
                break;

            case "Mouton":
                m_BeastVisu.mesh = s_VisuArray.a_MeshArray[2];
                break;

            case "Canard":
                m_BeastVisu.mesh = s_VisuArray.a_MeshArray[3];
                break;
        }
	    
	}
	
	
}
