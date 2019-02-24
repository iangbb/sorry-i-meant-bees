using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportJam : JamScript
{
    
    private GameObject player;

    public override void JamEffect(GameObject collidedPlayer)
    {
        player = collidedPlayer;
        player.GetComponent<portal_activate>().setPortalEnabled(true);
        print("Teleport your Enemies with this JAM!!!!!!!");;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started && !player.GetComponent<portal_activate>().getPortalEnabled())
        {
            //TODO Respawn
            print("Destroying " + gameObject);
            GameObject.Destroy(gameObject);
        }
    }
}
