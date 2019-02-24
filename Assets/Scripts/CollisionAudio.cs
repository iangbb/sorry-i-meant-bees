using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionAudio : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public bool hit = false;
    float prev_time;

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
        if (hit && Time.time - prev_time > 1)
        {
            source.PlayOneShot(clip);
            hit = false;
            prev_time = Time.time;
        }
    }


}