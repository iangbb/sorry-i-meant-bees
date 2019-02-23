using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JamScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collided = coll.gameObject;
        if (collided.tag == "Player") jamEffect(collided);
    }

    public abstract void jamEffect(GameObject player);
}
