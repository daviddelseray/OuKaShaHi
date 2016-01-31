using UnityEngine;
using System.Collections;

public class ScriptCharacterSoundManager : MonoBehaviour {


	// Call des fonctions callSoundDeath et callSoundRandom par le CharacterControl.
	//_____________________________________________________________________________

	// Sounds
	public AudioClip ac_DuckDeath;
	public AudioClip ac_SheepDeath; 
	public AudioClip ac_PigDeath;
	public AudioClip ac_SlothDeath;

	public AudioClip ac_DuckRandom;
	public AudioClip ac_SheepRandom;
	public AudioClip ac_PigRandom;
	public AudioClip ac_SlothRandom;

	AudioSource myAudio;
	// ___________________________________________________________

	// Use this for initialization
	void Start () {
		myAudio = GetComponent<AudioSource> ();
	}
	
	
	// Call le son de mort de chaque animaux q_character
	public void callSoundDeath(string q_character)
	{
		switch (q_character)
		{
			case "Mouton": 
				myAudio.PlayOneShot (ac_SheepDeath);
			break;
			case "Paresseux" :
				myAudio.PlayOneShot(ac_SlothDeath);
			break;
			case "Canard":
				myAudio.PlayOneShot (ac_DuckDeath);
			break;
			case "Cochon":
				myAudio.PlayOneShot (ac_PigDeath);
			break;
		}
	}

	// Call le son de base de chaque animaux q_character (pour départ et pour random pendant partie)
	public void callSoundRandom(string q_character)
	{
		switch (q_character)
		{
		case "Mouton": 
			myAudio.PlayOneShot (ac_SheepRandom);
			break;
		case "Paresseux" :
			myAudio.PlayOneShot(ac_SlothRandom);
			break;
		case "Canard":
			myAudio.PlayOneShot (ac_DuckRandom);
			break;
		case "Cochon":
			myAudio.PlayOneShot (ac_PigRandom);
			break;
		}
	}

}
