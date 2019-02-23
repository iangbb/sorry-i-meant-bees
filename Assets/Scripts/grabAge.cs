using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabAge : MonoBehaviour
{
    playerEngine playerScript;
    private Animator anim;
    public int player;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player " + player).GetComponent<playerEngine>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Age", playerScript.getAgeAnim());
        print(playerScript.getAgeAnim());
    }
}
