using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    
    // These fields must be customised in subclasses' Start() methods
    public float minSpawnInterval;
    public float maxSpawnInterval;
    public float minMeteoriteSpeed;
    public float maxMeteoriteSpeed;
    public int totalMeteorsToSpawn;// 0 results in infinite meteors

    public GameObject[] meteorPrefabs;
    
    private float width;
    private float height;

    private List<GameObject> players;

    void Start()
    {
        SetupMeteorSpawner();
        StartCoroutine(SpawnMeteorite());
    }

    protected void SetupMeteorSpawner()
    {
        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        width = cont.GetComponent<boundary_script>().width;
        height = cont.GetComponent<boundary_script>().height;
        players = new List<GameObject>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) players.Add(player);
    }

    protected IEnumerator SpawnMeteorite()
    {
        int meteorsSpawned = 0;
        while (totalMeteorsToSpawn == 0 || meteorsSpawned++ < totalMeteorsToSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            int edge = Random.Range(0, 4);
            float posX, posY;
            
            // Randomly select a prefab
            int meteor = Random.Range(0, meteorPrefabs.Length);
            GameObject meteorite = meteorPrefabs[meteor];

            if (edge % 2 == 0)
            {
                posX = Random.Range(-1 * (width / 2), width / 2);
                posY = (height / 2) * (edge - 1);
            }
            else
            {
                posY = Random.Range(-1 * (height / 2), height / 2);
                posX = (width / 2) * (edge - 2);
            }

            GameObject newMet = Instantiate(meteorite, new Vector2(posX, posY), new Quaternion());
            GameObject target = players[Random.Range(0, players.Count - 1)];
            Vector2 direction = target.transform.position - newMet.transform.position;
            float meteoriteSpeed = Random.Range(minMeteoriteSpeed, maxMeteoriteSpeed);
            Rigidbody2D meteorBody = newMet.GetComponent<Rigidbody2D>();
            meteorBody.AddForce(meteoriteSpeed * direction / direction.magnitude);
            meteorBody.AddTorque(Random.Range(1.0f, 3.0f)); // Add random spin
        }
    }
}