using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusic : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public bool ready;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        done = false;
        StartCoroutine(PlayMusicWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (!done && ready)
        {
            source.PlayOneShot(clip);
            done = true;
        }
       
    }

    private IEnumerator PlayMusicWithDelay()
    {
        yield return new WaitForSeconds(clip.length);
        done = true;
    }

    public bool getDone()
    {
        return done;
    }

    public void setReady(bool value)
    {
        ready = value;
    }
}