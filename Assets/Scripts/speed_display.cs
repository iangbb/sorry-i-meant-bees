using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed_display : MonoBehaviour
{

    public float speed;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameObject.Find("Player 1").GetComponent<info>().speed * 1000;
        speed = (int)speed;
        speedText.text = "Speed: " + speed;
    }
}
