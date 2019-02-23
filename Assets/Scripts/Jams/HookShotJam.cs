using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotJam : JamScript
{
    private GameObject player;
    private bool started = false;

    public float useTime = 5;

    public override void jamEffect(GameObject collidedPlayer)
    {
        player = collidedPlayer;
        print("from hookshot " + player);
        player.GetComponent<hookshot_script>().setHookShotEnabled(true);
        print("HOOKSHOT!!!!!!!");
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
                player.GetComponent<hookshot_script>().setHookShotEnabled(false);
                print("Destroying " + gameObject);
                GameObject.Destroy(gameObject);
                started = false;
            }
        }
    }
}
