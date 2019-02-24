using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightJamScript : JamScript
{
    public float useTime = 5;
    private bool started = false;
    private GameObject player;

    public override void JamEffect(GameObject playerCollided)
    {
        player = playerCollided;
        player.GetComponent<player_special_powers>().setWeightEnabled(true);
        print("Change your weight with the power of this JAM!!!!!");
        started = true;
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
        player.GetComponent<player_special_powers>().setWeightEnabled(false);
        GameObject.Destroy(gameObject);
        started = false;
    }
}
