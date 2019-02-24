using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    public string introScene;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
