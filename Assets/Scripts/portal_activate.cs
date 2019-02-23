using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_activate : MonoBehaviour
{
    public KeyCode portalKey;
    public Transform portalIn;
    public Transform portalOut;


    private List<GameObject> otherPlayers;
    float x;
    float y;

    private bool portalEnabled;

    // Start is called before the first frame update
    void Start()
    {
        otherPlayers = new List<GameObject>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player != gameObject)
            {
                otherPlayers.Add(player);
            }
        }
        portalEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(portalKey) && portalEnabled)
        {
            //creates portal in front of player
            foreach (GameObject player in otherPlayers)
            {
                Transform newPortalIn = Instantiate(portalIn, (Vector2) player.GetComponent<Transform>().position, Quaternion.identity);
                x = Random.Range(-8.91f, 8.93f);
                y = Random.Range(-5.0f, 5.0f);
                Transform newPortalOut = Instantiate(portalOut, new Vector2(x,y), Quaternion.identity);
                Object.Destroy(newPortalIn.gameObject, 3.0f);
                Object.Destroy(newPortalOut.gameObject, 3.0f);
            }
            portalEnabled = false;
        }
    }

    public void setPortalEnabled(bool w) { portalEnabled = w; }

    public bool getPortalEnabled() { return portalEnabled; }
}
