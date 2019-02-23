using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PullPushJamScript : JamScript
{
    public float useTime = 5;
    private bool started = false;
    private GameObject player;

    public override void jamEffect(GameObject playerCollided)
    {
        print(playerCollided);
        player = playerCollided;
        player.GetComponent<player_special_powers>().setPullPushEnabled(true);
        print("Pull and push with the power of this JAM!!!!!");
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
            print(useTime);
            if (useTime < 0)
            {
                player.GetComponent<player_special_powers>().setPullPushEnabled(false);
                print("Destroying " + gameObject);
                GameObject.Destroy(gameObject);
                started = false;
            }
        }
    }


}
