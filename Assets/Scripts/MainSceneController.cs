using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public string endScene;

    public GameObject player1;
    public GameObject player2;

    public Text player1Controls;
    public Text player2Controls;

    public float showControlTime = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator showControls(GameObject player, Text text)
    {
        yield return new WaitForSeconds(showControlTime);
    }
}
