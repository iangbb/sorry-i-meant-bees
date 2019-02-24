using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public string endScene;

    public GameObject player1;
    public GameObject player2;

    public Text player1Controls;
    public Text player2Controls;

    public GameObject player1Image;
    public GameObject player2Image;

    public float showControlTime = 10;

    private bool showControlInfo;

    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        showControlInfo = false;
        player1Controls.text = "";
        player2Controls.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<playerEngine>().getAge() > 115)
        {
            GameObject.DontDestroyOnLoad(player2);
            GameObject.Destroy(player1Image);
            SceneManager.LoadScene(endScene, LoadSceneMode.Single);
        }else if (player2.GetComponent<playerEngine>().getAge() > 115)
        {
            GameObject.DontDestroyOnLoad(player1);
            GameObject.Destroy(player2Image);
            SceneManager.LoadScene(endScene, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) toggleControls();
    }

    private void toggleControls()
    {
        if (showControlInfo)
        {
            player1Controls.text = "";
            player2Controls.text = "";
            showControlInfo = false;
        } else
        {
            player1Controls.text = getControlText(player1);
            player2Controls.text = getControlText(player2);
            showControlInfo = true;
        }
    }

    private string getControlText(GameObject player)
    {
        string controlText = "";
        playerEngine eng = player.GetComponent<playerEngine>();
        portal_activate por = player.GetComponent<portal_activate>();
        player_special_powers spec = player.GetComponent<player_special_powers>();
        hookshot_script hook = player.GetComponent<hookshot_script>();
        controlText += "Up: " + eng.up + "\n";
        controlText += "Left: " + eng.left + "\n";
        controlText += "Right: " + eng.right + "\n";
        controlText += "Down: " + eng.down + "\n";
        controlText += "Jams\n";
        controlText += "Portal: " + por.portalKey + "\n";
        controlText += "- Weight: " + spec.levitateKey + "\n";
        controlText += "+ Weight: " + spec.antiLeviKey + "\n";
        controlText += "Push: " + spec.pushKey + "\n";
        controlText += "Pull: " + spec.pullKey + "\n";
        controlText += "HookShot Left: " + hook.hookshotLeftKey + "\n";
        controlText += "HookShot Right: " + hook.hookshotRightKey + "\n";
        return controlText;
    }
}
