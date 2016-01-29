using UnityEngine;
using System.Collections;

public class ScriptArenaLifeZone : MonoBehaviour {

	void OnTriggerExit(Collider Other)
    {
        Debug.Log("OY");
    }
}
