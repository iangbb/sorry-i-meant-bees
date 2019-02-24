using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_in_behaviour : MonoBehaviour
{
    
    private GameObject portalOut;
    private Vector2 outPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        portalOut = GameObject.Find("portalOut(Clone)");
        outPosition = portalOut.GetComponent<Transform>().position;
        col.gameObject.GetComponent<Rigidbody2D>().transform.position = outPosition;        
    }
}
