using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleport_text : MonoBehaviour
{
    public int player;
    public Text teleportText;
    portal_activate playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player " + player).GetComponent<portal_activate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.getPortalEnabled())
            teleportText.text = "TELEPORT";
        else
            teleportText.text = "";
    }
}
