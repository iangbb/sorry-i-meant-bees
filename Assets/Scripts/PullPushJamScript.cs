using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPushJamScript : JamScript
{
    public override void jamEffect(GameObject player)
    {
        print(player);
        player.GetComponent<player_special_powers>().setPullPushEnabled(true);
        print("Pull and push with the power of this JAM!!!!!");
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
