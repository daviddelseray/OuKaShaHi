using UnityEngine;
using System.Collections;

public class ScriptDeadZone : MonoBehaviour
{
    public int m_Number;

    Vector3 v3_SpreadScale;
    Vector3 v3_ContractScale;

    void Awake ()
    {
        v3_ContractScale = new Vector3(0f, 0f, 0f);
        v3_SpreadScale = new Vector3(1f, 1f, 1f);

        this.transform.localScale = v3_ContractScale;
    }
		
	void OnTriggerEnter (Collider Other)
    {
        if (Other.tag == "Player")
        {
            Other.GetComponent<ScriptCharacterControl>().m_IsAlive = false;
           
        }
    }

   
    public void Attack ()
    {
        StartCoroutine(C_Attack());

    }

    IEnumerator C_Attack ()
    {
        this.transform.localScale = v3_SpreadScale;
        yield return new WaitForSeconds(0.01f);
        this.transform.localScale = v3_ContractScale;
    }
}
