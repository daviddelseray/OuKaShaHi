using UnityEngine;
using System.Collections;

public class ScriptPlayerNumber : MonoBehaviour {

    public int m_PlayersNumber;

    public GameObject m_Characters;

    public void NumberOfPlayers(int PlayerNumber)
    {
        m_PlayersNumber = PlayerNumber;
        PlayerPrefs.SetInt("m_PlayersNumber", PlayerNumber);
        m_Characters.SetActive(true);
        this.gameObject.SetActive(false);
    }

}