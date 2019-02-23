using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class age_ui_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private playerEngine pE;
    private Text txt;

    void Start()
    {
        pE = player.GetComponent<playerEngine>();
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = pE.getAge() + "";
    }
}
