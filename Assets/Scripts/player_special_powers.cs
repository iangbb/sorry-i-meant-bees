using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_special_powers : MonoBehaviour
{
    private List<GameObject> otherPlayers;

    public KeyCode pullKey;
    public KeyCode pushKey;
    public KeyCode levitateKey;
    public float strength;

    // Start is called before the first frame update
    void Start()
    {
        otherPlayers = new List<GameObject>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player != gameObject)
            {
                otherPlayers.Add(player);
                print(player);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pullKey))
        {
            foreach (GameObject player in otherPlayers)
            {
                addForce(player, strength * (-1));
            }
        } else if (Input.GetKeyDown(pushKey))
        {
            foreach (GameObject player in otherPlayers)
            {
                addForce(player, strength);
            }
        } else if (Input.GetKeyDown(levitateKey))
        {

        }
    }

    private void addForce(GameObject player, float force)
    {
        Vector3 direction = player.transform.position - gameObject.transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(
            gameObject.GetComponent<playerEngine>().getAge()  * force * direction
            / (Mathf.Pow(direction.magnitude, 2)) * gameObject.GetComponent<info>().mass);
    }
}
