using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabAge : MonoBehaviour
{
    private playerEngine playerScript;
    private Animator anim;
    public int player;
    private int ageId;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player " + player).GetComponent<playerEngine>();
        anim = GetComponent<Animator>();
        ageId = Animator.StringToHash("Age");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger(ageId, playerScript.getAgeAnim());
    }
}
