using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ScriptMenuControl : MonoBehaviour
{


    //Script

    public ScriptCharacterSelection s_Characters;

    //_________________________________________________________________________________

    //Public Vars


    public Button[] a_PlayersButton = new Button[4];

    public List<Button> l_CharactersButton = new List<Button>();

    public GameObject go_PanelPlayersNumber;
    public GameObject go_PanelCharacters;

    //________________________________________________________________________________

    //Private Vars

    int m_PlayersIndex = 0;
    int m_ArchetypeIndex = 0;

    bool m_Tempo = true;

    bool m_Tempo2 = true;

    bool m_ReadyToGo = true;

    string m_DirectControl;
    string m_ButtonControl;

    //_________________________________________________________________________________



    // Update is called once per frame
    void FixedUpdate()
    {
        if ((go_PanelPlayersNumber.active) && (!(go_PanelCharacters.active)))
        {
            if ((Input.GetAxis("VerticalPlayer1") < 0) && (m_Tempo == true))
            {

                Debug.Log("OY");

                if (m_PlayersIndex <= 2)
                {
                    m_PlayersIndex++;


                }

                m_Tempo = false;

                StartCoroutine(Temporisation());

            }
            else if ((Input.GetAxis("VerticalPlayer1") > 0) && (m_Tempo == true))
            {

                if (m_PlayersIndex >= 1)
                {
                    m_PlayersIndex--;
                }

                m_Tempo = false;

                StartCoroutine(Temporisation());
            }

            a_PlayersButton[m_PlayersIndex].Select();

            if (Input.GetButton("Fire1Player1"))
            {
                m_ReadyToGo = false;
                StartCoroutine(Temporisation2());
                a_PlayersButton[m_PlayersIndex].onClick.Invoke();
            }

        }

        if (!(go_PanelPlayersNumber.active) && (go_PanelCharacters.active) && (m_ReadyToGo == true))
        {
            ControlAttribution();


            if ((Input.GetAxis(m_DirectControl) > 0) && (m_Tempo == true))
            {

                if (m_ArchetypeIndex <= 2)
                {
                    m_ArchetypeIndex++;


                }

                m_Tempo = false;

                StartCoroutine(Temporisation());

            }
            else if ((Input.GetAxis(m_DirectControl) < 0) && (m_Tempo == true))
            {
                m_Tempo = false;

                if (m_ArchetypeIndex >= 1)
                {
                    m_ArchetypeIndex--;
                }



                StartCoroutine(Temporisation());
            }

            l_CharactersButton[m_ArchetypeIndex].Select();

            if ((Input.GetButtonDown(m_ButtonControl)) && (m_Tempo2 == true))
            {


                StartCoroutine(Select());


            }

        }


    }

    IEnumerator Temporisation()
    {
        yield return new WaitForSeconds(0.5f);

        m_Tempo = true;
    }

    IEnumerator Temporisation2()
    {
        yield return new WaitForSeconds(0.5f);

        m_ReadyToGo = true;
    }


    IEnumerator Temporisation3()
    {
        yield return new WaitForSeconds(0.5f);

        m_Tempo2 = true;
    }

    IEnumerator Select()
    {
        m_Tempo2 = false;
        l_CharactersButton[m_ArchetypeIndex].onClick.Invoke();
        l_CharactersButton.RemoveAt(m_ArchetypeIndex);
        yield return new WaitForSeconds(0.5f);
        ControlAttribution();
        StartCoroutine(Temporisation3());


        Reselect();
        yield return new WaitForSeconds(0.5f);
    }

    void Reselect()
    {
        l_CharactersButton[0].Select();
    }

    void ControlAttribution()
    {
        switch (s_Characters.m_SelectingPlayer)
        {
            case 1:
                m_DirectControl = "HorizontalPlayer1";
                m_ButtonControl = "Fire1Player1";
                break;

            case 2:
                m_DirectControl = "HorizontalPlayer2";
                m_ButtonControl = "Fire1Player2";
                break;

            case 3:
                m_DirectControl = "HorizontalPlayer3";
                m_ButtonControl = "Fire1Player3";
                break;

            case 4:
                m_DirectControl = "HorizontalPlayer4";
                m_ButtonControl = "Fire1Player4";
                break;
        }



    }
}
