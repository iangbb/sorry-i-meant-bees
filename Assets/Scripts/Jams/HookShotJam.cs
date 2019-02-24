using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotJam : JamScript
{
    
    private GameObject player;

    public float useTime = 5;

    public override void JamEffect(GameObject collidedPlayer)
    {
        player = collidedPlayer;
        print("from hookshot " + player);
        player.GetComponent<hookshot_script>().SetHookShotEnabled(true);
        print("HOOKSHOT!!!!!!!");
        StartCoroutine(UseJam());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator UseJam()
    {
        yield return new WaitForSeconds(useTime);
        player.GetComponent<hookshot_script>().SetHookShotEnabled(false);
        print("Destroying " + gameObject);
        GameObject.Destroy(gameObject);
    }
    
}
