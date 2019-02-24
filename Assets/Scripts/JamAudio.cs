using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JamAudio : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public bool hit = false;

    // Use this for initialization
    void Start()
    {

    }

    public void setHit(bool state)
    {
        hit = state;
    }

    private void Update()
    {
        if (hit)
        {
            source.PlayOneShot(clip);
            hit = false;
        }
    }


}