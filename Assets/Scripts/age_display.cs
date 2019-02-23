using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class age_display : MonoBehaviour
{
    public int age;
    public Text ageText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ageText.text = "Age: " + age;
    }
}
