using UnityEngine;
using UnityEngine.UI;

public class age_display : MonoBehaviour
{
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
        ageText.text = ((int) playerScript.getAge()).ToString();
    }
}
