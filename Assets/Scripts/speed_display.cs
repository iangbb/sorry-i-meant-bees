using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed_display : MonoBehaviour
{

    public Text speedText;
    public int player;

    private info playerInfoComponent;

    // Start is called before the first frame update
    void Start()
    {
        playerInfoComponent = GameObject.Find("Player " + player).GetComponent<info>();
        StartCoroutine(DisplaySpeed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DisplaySpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            int speed = (int) (playerInfoComponent.speed * 100);
            speedText.text = "SPEED: " + speed;
        }
    }
}
