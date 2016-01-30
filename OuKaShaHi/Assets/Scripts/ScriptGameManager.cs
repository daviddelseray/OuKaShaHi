﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptGameManager : MonoBehaviour
{
  
    //_______________________________________________________________________

   //Texts Lists
  

    public List<string> l_TextBank = new List<string>();

    List<string> l_Reading = new List<string>();

   //__________________________________________________________________________

   // Sound List
   

    public List<AudioClip> l_SoundBank = new List<AudioClip>();

    List<AudioClip> l_Playing = new List<AudioClip>();


    //__________________________________________________________________________

    // Various Variables
    float m_TextBankLength;

    public int m_SequenceLength;

    int m_Index;

    int m_FillBankIndex;

    int[] a_ExclusionArray = new int[4];

    bool m_CheckIsGood;

    int m_DifficultyLevel=1;

    //_____________________________________________________________________________
    // Levels of Difficulty
    public int m_Difficulty1;
    public int m_Difficulty2;
    public int m_Difficulty3;
    public int m_Difficulty4;




    //_____________________________________________________________________________
    //Components

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

    void FillingSequence()// Remplissage de la séquence, on prend dans une liste de stockage les textes des cris (affichages next) et les sons dans une autre et on les mets dans deux listes de lecture
    {
        for (int i = 0; i<m_SequenceLength; i++)
        {
            m_Index = Mathf.FloorToInt(Random.Range(0,m_TextBankLength));
            l_Reading.Add(l_TextBank[m_Index]);
            l_Playing.Add(l_SoundBank[m_Index]);

            Debug.Log(l_Reading[l_Reading.Count-1]);
        }

        
    } 

   /* void FillingBanks()
    {
        for (int k =0; k<4;k++)
        {
            m_FillBankIndex = Mathf.FloorToInt(Random.Range(0, l_TextsHere.Count));

        }
    }
    */
    /*void CheckingIndex()
    {
        for (int l = 0; l<=a_ExclusionArray.Length-1;l++)
        {

        }
    }
    */

    void LaunchSequence ()
    {
        switch(m_DifficultyLevel)
        {
            case 1:
                m_SequenceLength = m_Difficulty1;
                break;

            case 2:
                m_SequenceLength = m_Difficulty2;
                break;


            case 3:
                m_SequenceLength = m_Difficulty3;
                break;


            case 4:
                m_SequenceLength = m_Difficulty4;
                break;
         }


    }


   IEnumerator ReadingSequence ()// Lecture de la séquence, on parcourt les listes de lecture pour afficher les textes et pour jouer les sons
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
