using System.Collections;
using System.Collections.Generic;
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

    public const float waitTime = 3f;

    void Start()
    {
        ready = false;
        introText.text = "";
        title.text = "";
        player2.SetActive(false);
        player1.SetActive(false);
        StartCoroutine(showIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if (ready && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        }
    }

    private IEnumerator showIntro()
    {
        yield return new WaitForSeconds(2);
        introText.text = "A long time ago,\nin a galaxy far far away...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...there were these twins...";
        player2.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        introText.text = "...which one might describe as ...";
        player1.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        introText.text = "...quite competitive.";
        yield return new WaitForSeconds(waitTime);
        introText.text = "After competing over fame,\nmoney and power...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...and some other things\nwhich I don't say here...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...they needed some\nnew challenges.";
        yield return new WaitForSeconds(waitTime);
        introText.text = "Since they're twins,\nthey had obviously always\nbeen of the same age.";
        yield return new WaitForSeconds(waitTime);
        introText.text = "What if they could\ncompete over staying young?";
        yield return new WaitForSeconds(waitTime);
        introText.text = "They had already used\nall the usual ways...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...supreme medicine, exercise\nyou name it...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...but as we all know...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...there is one really simple\nway to stay young...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...";
        yield return new WaitForSeconds(waitTime);
        introText.text = "...to move at a high speed.";
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
        title.text = "Twin Paradox";
        yield return new WaitForSeconds(waitTime);
        introText.transform.position -= new Vector3(0, 10, 0);
        introText.text = "Press space to start.";
        ready = true;
    }
}
