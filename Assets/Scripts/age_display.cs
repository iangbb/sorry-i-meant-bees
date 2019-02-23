using UnityEngine;
using UnityEngine.UI;

public class age_display : MonoBehaviour
{
    public int age;
    public Text ageText;
    public playerEngine playerScript;
    public int player;
    
    void Start()
    {
        playerScript = GameObject.Find("Player " + player).GetComponent<playerEngine>();
        transform.SetAsLastSibling();
    }

    
    void Update()
    {
        age = (int)playerScript.getAge();
        ageText.text = "" + age;
    }
}
