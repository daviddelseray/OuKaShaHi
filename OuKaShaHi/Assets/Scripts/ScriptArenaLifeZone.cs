using UnityEngine;
using System.Collections;

public class ScriptArenaLifeZone : MonoBehaviour {

	void OnTriggerExit(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Other.GetComponent<ScriptCharacterControl>().m_IsAlive = false;
        }
    }
}
