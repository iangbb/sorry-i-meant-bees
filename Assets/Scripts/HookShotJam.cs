using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotJam : JamScript
{
    private GameObject player;
    private bool started = true;

    public float useTime = 5;

    public override void jamEffect(GameObject collidedPlayer)
    {
        player = collidedPlayer;
        player.GetComponent<portal_activate>().setPortalEnabled(true);
        print("Teleport your Enemies with this JAM!!!!!!!");
        started = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            useTime -= Time.deltaTime;
            if (useTime < 0)
            {
                player.GetComponent<portal_activate>().setPortalEnabled(false);
                print("Destroying " + gameObject);
                GameObject.Destroy(gameObject);
            }
        }
    }
}
