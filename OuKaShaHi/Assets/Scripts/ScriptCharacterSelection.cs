using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptCharacterSelection : MonoBehaviour
{
    public int m_SelectingPlayer;

    [HideInInspector]
    public string m_Character1;

    [HideInInspector]
    public string m_Character2;

    [HideInInspector]
    public string m_Character3;

    [HideInInspector]
    public string m_Character4;



    public Text m_Instruction;

    public int m_PlayersNumber;

    // Use this for initialization
    void Start()
    {
        m_PlayersNumber = PlayerPrefs.GetInt("m_PlayersNumber");
        m_SelectingPlayer = 1;

        TextDisplay();

    }



    public void CharacterSelection (string m_Role)
    {
        switch (m_SelectingPlayer)
        {
            case 1:
                PlayerPrefs.SetString("m_Character1", m_Role);

                break;

            case 2:
                PlayerPrefs.SetString("m_Character2", m_Role);
                break;

            case 3:
                PlayerPrefs.SetString("m_Character3", m_Role);
                break;

            case 4:
                PlayerPrefs.SetString("m_Character4", m_Role);
                break;

        }

        if (m_SelectingPlayer < m_PlayersNumber)
        {
            m_SelectingPlayer++;
            TextDisplay();

        }

        else if (m_SelectingPlayer >= m_PlayersNumber)
        {

            this.gameObject.SetActive(false);
            Application.LoadLevel("TestScene");

        }

    }

    public void TextDisplay()
    {
        switch (m_SelectingPlayer)
        {
            case 1:
                m_Instruction.text = "Player1,select your character.";
                break;

            case 2:
                m_Instruction.text = "Player2,select your character.";
                break;

            case 3:
                m_Instruction.text = "Player3,select your character.";
                break;

            case 4:
                m_Instruction.text = "Player4,select your character.";
                break;
        }
    }



}
