using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.PlayOneShot(clip);
        }
    }


}