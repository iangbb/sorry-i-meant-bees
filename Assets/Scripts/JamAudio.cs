using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JamAudio : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public bool hit = false;
    public float volume = 0.1f;

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
            source.PlayOneShot(clip, volume);
            hit = false;
        }
    }


}