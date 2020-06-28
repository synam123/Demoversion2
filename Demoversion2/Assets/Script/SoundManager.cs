using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coin, jump, die, theme, clear;

    public AudioSource adisrc;
    // Start is called before the first frame update
    void Start()
    {
        coin = Resources.Load<AudioClip>("smb_coin");
        jump = Resources.Load<AudioClip>("smb_jump-super");
        die = Resources.Load<AudioClip>("smb_mariodie");
        clear = Resources.Load<AudioClip>("clear");
        theme = Resources.Load<AudioClip>("theme");

        adisrc = GetComponent<AudioSource>();
    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coin;
                adisrc.PlayOneShot(coin, 1f);
                break;

            case "jumps":
                adisrc.clip = jump;
                adisrc.PlayOneShot(jump, 1f);
                break;

            case "death":
                adisrc.clip = die;
                adisrc.PlayOneShot(die, 1f);
                break;

            case "clears":
                adisrc.clip = clear;
                adisrc.PlayOneShot(clear, 1f);
                break;

            case "themes":
                adisrc.clip = theme;
                adisrc.PlayOneShot(theme, 1f);
                break;
        }
    }
}
