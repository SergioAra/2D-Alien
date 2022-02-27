using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shortShot, chargedShot, bulletImpact, chargedImpact, theme, cowDead, dogDead, chickenDead, chargeLoop, fullyCharged;
    static AudioSource audioSrc;
	private static string LastSound;
    // Start is called before the first frame update
    void Start()
    {
        shortShot = Resources.Load<AudioClip>("shortShot");
        chargedShot = Resources.Load<AudioClip>("largeShot");
        bulletImpact = Resources.Load<AudioClip>("lightImpact");
        chargedImpact = Resources.Load<AudioClip>("chargedImpact");
        theme = Resources.Load<AudioClip>("background");
        cowDead = Resources.Load<AudioClip>("cowDead");
        chickenDead = Resources.Load<AudioClip>("chickenDead");
        dogDead = Resources.Load<AudioClip>("dogDead");
		chargeLoop = Resources.Load<AudioClip>("Chargeloop");
		fullyCharged = Resources.Load<AudioClip>("FullyCharged");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) 
	{ 
		LastSound = clip;
        switch (clip)
        {
            case "shortShot":
                audioSrc.PlayOneShot(shortShot);
                break;
            case "chargedShot":
                audioSrc.PlayOneShot(chargedShot);
                break;
            case "bulletImpact":
                audioSrc.PlayOneShot(bulletImpact);
                break;
            case "chargedImpact":
                audioSrc.PlayOneShot(chargedImpact);
                break;
            case "cowDead":
                audioSrc.PlayOneShot(cowDead);
                break;
            case "chickenDead":
                audioSrc.PlayOneShot(chickenDead);
                break;
            case "dogDead":
                audioSrc.PlayOneShot(dogDead);
                break;
			case "chargeLoop":
				audioSrc.PlayOneShot(chargeLoop);
				break;
			case "FullyCharged":
				audioSrc.PlayOneShot(fullyCharged);
				break;
            default:
                audioSrc.PlayOneShot(shortShot);
                break;
        }

        //Debug.Log(clip);
        
    }
	
	public static void StopSound(string clip)
	{
		if(LastSound == clip)
		audioSrc.Stop();
	}	
}
