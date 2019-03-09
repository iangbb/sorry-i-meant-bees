using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public string gameSceneName;

    public Text introText;

    public Text title;

    private bool ready;

    public GameObject player1;
    public GameObject player2;

    public GameObject player1Image;
    public GameObject player2Image;

    public GameObject titleImage;

    public const float waitTime = 3f;

    private bool showControlInfo;
    public float showControlTime = 10;
    public Text player1Controls;
    public Text player2Controls;

    public bool show;

    void Start()
    {
        ready = false;
        introText.text = "";
        title.text = "";
        player2.SetActive(false);
        player1.SetActive(false);
        player1Image.SetActive(false);
        player2Image.SetActive(false);
        titleImage.SetActive(false);
        StartCoroutine(showIntro());
        showControlInfo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) toggleControls();

        if (!show)
        {
            player2.SetActive(false);
            player2Image.SetActive(false);
        }
    }

    private IEnumerator showIntro()
    {
        
        yield return new WaitForSeconds(2);
        introText.text = "A long time ago,\nin a galaxy far far away...";
        ready = true;
        yield return new WaitForSeconds(waitTime);
        GetComponent<IntroMusic>().setReady(true);
        introText.text = "...there were these twins...";
        player1.SetActive(true);
        player1Image.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        introText.text = "...which one might describe as ...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...quite competitive.";
        show = true;
        player2.SetActive(true);
        player2Image.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        introText.text = "After competing over fame,\nmoney and power...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...and some other things\nwhich I don't dare say...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...they needed some\nnew challenges.";
        yield return new WaitForSeconds(waitTime);
        introText.text = "Since they're twins,\nthey had obviously always\nbeen of the same age.";
        yield return new WaitForSeconds(waitTime);
        introText.text = "What if they could\ncompete over staying young?";
        yield return new WaitForSeconds(waitTime);
        introText.text = "They had already used\nall the usual ways...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...supreme medicine, exercise,\nyou name it...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...but as we all know...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...there is one really simple\nway to stay young...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...GO FAST!!!";
        yield return new WaitForSeconds(waitTime);
        introText.text = "";
        yield return new WaitForSeconds(waitTime);
        introText.text = "So the twins headed\nto outer space...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...to travel as fast\nas they could...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...and wait for the\nother one to die first.";
        yield return new WaitForSeconds(waitTime);
        introText.text = "";
        yield return new WaitForSeconds(waitTime);
        titleImage.SetActive(true);
        player1.SetActive(false);
        player2.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        introText.transform.position -= new Vector3(0, 20, 0);
        introText.text = "Press space to start.";
    }
    
    private void toggleControls()
    {
        if (showControlInfo)
        {
            player1Controls.text = "";
            player2Controls.text = "";
            showControlInfo = false;
        }
        else
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
