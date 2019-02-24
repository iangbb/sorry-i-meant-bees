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

    public bool ready;

    void Start()
    {
        ready = false;
        introText.text = "";
        title.text = "";
        showIntro();
    }

    // Update is called once per frame
    void Update()
    {
        if (ready && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        }
    }

    private void showIntro()
    {
        introText.text = "A long time ago, in a galaxy far far away...";
    }
}
