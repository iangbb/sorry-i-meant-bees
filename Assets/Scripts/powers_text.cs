using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powers_text : MonoBehaviour
{
    public int player;
    public Text powersText;
    private portal_activate portalScript;
    private hookshot_script hookshotScript;
    private player_special_powers specialScript;
    private string tempText;
    
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
        tempText = "";
        if (portalScript.getPortalEnabled())
            tempText += "TELEPORT\n ";
        if (hookshotScript.GetHookShotEnabled())
            tempText += "HOOKSHOT\n ";
        if (specialScript.getWeightEnabled())
            tempText += "MASS UP/DOWN\n ";
        if (specialScript.getPullPushEnabled())
            tempText += "PULL/PUSH ";
        powersText.text = tempText;
    }
}
