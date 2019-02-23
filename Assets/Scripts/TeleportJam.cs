using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportJam : JamScript
{
    public override void jamEffect(GameObject player)
    {
        player.GetComponent<portal_activate>().setPortalEnabled(true);
        print("Teleport your Enemies with this JAM!!!!!!!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
