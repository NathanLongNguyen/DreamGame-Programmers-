using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public static AudioClip PlayerHurt;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		PlayerHurt = Resources.Load<AudioClip> ("PlayerHurt");
		
        audioSrc = GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound ( string clip){

		switch(clip) {
		case "PlayerHurt":
			audioSrc.PlayOneShot (PlayerHurt);
			break;
		case "PlayerMove":
			audioSrc.PlayOneShot (PlayerMove);
			break;
		case "PlayerAttack":
			audioSrc.PlayOneShot (PlayerAttack);
                //Debug.Log("Played");
			break;
		case "EnemyAttack":
			audioSrc.PlayOneShot (EnemyAttack);
			break;
		case "EnemyHurt":
			audioSrc.PlayOneShot (enemyHurt);
			break;
		case "PickUp":
			audioSrc.PlayOneShot (PickUp);
			break;
		case "lvlUP":
			audioSrc.PlayOneShot (lvlUP);
			break;
		case "Jumping":
			audioSrc.PlayOneShot (Jumping);
			break;
		case "Shift":
			audioSrc.PlayOneShot (Shift);
			break;
        case "Flame":
                audioSrc.PlayOneShot(Flame);
                break;
        case "BowHit":
                audioSrc.PlayOneShot(Bow_hit);
                break;
        case "BowShoot":
                audioSrc.PlayOneShot(Bow_shoot);
                break;
        case "rolled":
                audioSrc.PlayOneShot(rolled);
                break;
        }
}


}
