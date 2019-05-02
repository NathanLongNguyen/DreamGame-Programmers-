using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public static AudioClip PlayerHurt, EnemyHurt, KnifeThrow, KnifeMelee, Mat_hit;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		PlayerHurt = Resources.Load<AudioClip> ("PlayerHurt");
        EnemyHurt = Resources.Load<AudioClip>("EnemyHurt");
        KnifeThrow = Resources.Load<AudioClip>("knife_throw_low");
        KnifeMelee = Resources.Load<AudioClip>("melee_hit");
        Mat_hit = Resources.Load<AudioClip>("hit_material");

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
		case "EnemyHurt":
			audioSrc.PlayOneShot (EnemyHurt);
			break;
		case "KnifeThrow":
			audioSrc.PlayOneShot (KnifeThrow);
			break;
		case "KnifeMelee":
			audioSrc.PlayOneShot (KnifeMelee);
			break;
		case "Mat_hit":
			audioSrc.PlayOneShot (Mat_hit);
			break;
		/*case "Shift":
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
                break;*/
        }
}


}
