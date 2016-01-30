using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptGameManager : MonoBehaviour
{
   public int m_SequenceLength;

    public List<string> l_TextBank = new List<string>();

    List<string> l_Reading = new List<string>();

    float m_TextBankLength;

    int m_Index;

    public List<AudioClip> l_SoundBank = new List<AudioClip>();

    List<AudioClip> l_Playing = new List<AudioClip>();

    AudioSource as_Speaker;
    
	// Use this for initialization
	void Start ()
    {
        as_Speaker = this.GetComponent<AudioSource>();

        m_TextBankLength = l_TextBank.Count;

        FillingSequence();
       StartCoroutine( ReadingSequence());
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void FillingSequence()
    {
        for (int i = 0; i<m_SequenceLength; i++)
        {
            m_Index = Mathf.FloorToInt(Random.Range(0,m_TextBankLength));
            l_Reading.Add(l_TextBank[m_Index]);
            l_Playing.Add(l_SoundBank[m_Index]);

            Debug.Log(l_Reading[l_Reading.Count-1]);
        }

        
    } 

   IEnumerator ReadingSequence ()
    {
        for(int j=0; j <m_SequenceLength;j++)
        {
            as_Speaker.clip = l_Playing[j];
            as_Speaker.Play();

            yield return new WaitForSeconds(l_Playing[j].length);
            Debug.Log(l_Reading[j]);

        }
    }
}
