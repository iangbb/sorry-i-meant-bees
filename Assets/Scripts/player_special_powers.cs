using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_special_powers : MonoBehaviour
{
    private List<GameObject> otherPlayers;

    public KeyCode pullKey;
    public KeyCode pushKey;
    public KeyCode levitateKey;
    public KeyCode antiLeviKey;
    public float strength;

    private float origMass;

    private float minMass = 0.001f;
    private float maxMass = 1000;

    public float weightRestoreTime = 3;
    private float weightRestDelta;

    private bool weightEnabled;
    private bool pullPushEnabled;
    
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
        origMass = gameObject.GetComponent<info>().mass;
        weightEnabled = false;
        pullPushEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mass = gameObject.GetComponent<info>().mass;
        if (Input.GetKeyDown(pullKey))
        {
            foreach (GameObject player in otherPlayers)
            {
                addForce(player, strength * (-1));
            }
        }

        if (Input.GetKeyDown(pushKey))
        {
            foreach (GameObject player in otherPlayers)
            {
                addForce(player, strength);
            }
        }

        if (Input.GetKeyDown(levitateKey))
        {
            useMassPower(mass / 2);
        }

        if (Input.GetKeyDown(antiLeviKey))
        {
            useMassPower(mass * 2);
        }

        updateMass();
    }

    private void updateMass()
    {
        float newMass = gameObject.GetComponent<info>().mass + Time.deltaTime * weightRestDelta;
        if ((newMass < origMass && weightRestDelta < 0) || (newMass > origMass && weightRestDelta > 0))
        {
            newMass = origMass;
            weightRestDelta = 0;
        }
        gameObject.GetComponent<info>().mass = newMass;
    }

    private void useMassPower(float newMass)
    {
        if (!weightEnabled || newMass < minMass || newMass > maxMass) return;

        weightRestDelta = (origMass - newMass) / weightRestoreTime;
        gameObject.GetComponent<info>().mass = newMass;
        weightEnabled = false;
    }

    private void addForce(GameObject player, float force)
    {
        if (!pullPushEnabled) return;

        pullPushEnabled = false;
        Vector3 direction = player.transform.position - gameObject.transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(
            gameObject.GetComponent<playerEngine>().getAge()  * force * direction
            / (Mathf.Pow(direction.magnitude, 2)) * gameObject.GetComponent<info>().mass);
    }

    public bool getWeightEnabled()
    {
        return weightEnabled;
    }

    public void setWeightEnabled(bool w)
    {
        weightEnabled = w; 
    }

    public bool getPullPushEnabled()
    {
        return pullPushEnabled;
    }

    public void setPullPushEnabled(bool w)
    {
        pullPushEnabled = w;
    }
}
