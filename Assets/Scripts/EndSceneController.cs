using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    public string introScene;
    public GameObject endImage;
    public GameObject showStuff;

    // Start is called before the first frame update
    void Start()
    {
        endImage.SetActive(false);
        showStuff.SetActive(false);
        StartCoroutine(showEndCredits());
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Destroy(GameObject.Find("Canvas"));
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
                GameObject.Destroy(player);
            }
            SceneManager.LoadScene(introScene, LoadSceneMode.Single);
        }
    }

    private IEnumerator showEndCredits()
    {
        print("cool");
        yield return new WaitForSeconds(5);
        endImage.SetActive(true);
        showStuff.SetActive(true);
        print("cool");
        GameObject.Destroy(GameObject.Find("Canvas"));
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            GameObject.Destroy(player);
        }
        

    }
}
