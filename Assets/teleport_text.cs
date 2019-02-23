using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powers_text : MonoBehaviour
{
    public int player;
    public Text powersText;
    portal_activate portalScript;
    hookshot_script hookshotScript;
    player_special_powers specialScript;
    string temp_text;
    // Start is called before the first frame update
    void Start()
    {
        portalScript = GameObject.Find("Player " + player).GetComponent<portal_activate>();
        hookshotScript = GameObject.Find("Player " + player).GetComponent<hookshot_script>();
        specialScript = GameObject.Find("Player " + player).GetComponent<player_special_powers>();
    }

    // Update is called once per frame
    void Update()
    {
        temp_text = "";
        if (portalScript.getPortalEnabled())
            temp_text += "TELEPORT\n ";
        if (hookshotScript.getHookShotEnabled())
            temp_text += "HOOKSHOT\n ";
        if (specialScript.getWeightEnabled())
            temp_text += "MASS UP/DOWN\n ";
        if (specialScript.getPullPushEnabled())
            temp_text += "PULL/PUSH ";
        powersText.text = temp_text;
    }
}
