using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PullPushJamScript : JamScript
{
    
    public float useTime = 5;
    private GameObject player;

    public override void JamEffect(GameObject playerCollided)
    {
        print(playerCollided);
        player = playerCollided;
        player.GetComponent<player_special_powers>().setPullPushEnabled(true);
        print("Pull and push with the power of this JAM!!!!!");
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
        player.GetComponent<player_special_powers>().setPullPushEnabled(false);
        print("Destroying " + gameObject);
        GameObject.Destroy(gameObject);
    }


}
