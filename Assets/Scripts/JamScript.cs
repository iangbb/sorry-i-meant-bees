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

    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject collided = coll.gameObject;
        if (collided.CompareTag("Player"))
            JamEffect(collided);
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public abstract void JamEffect(GameObject player);
}
