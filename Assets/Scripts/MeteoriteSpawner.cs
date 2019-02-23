using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public float minSpawnInterval = 3;
    public float maxSpawnInterval = 4;
    public float minMeteoriteSpeed = 200;
    public float maxMeteoriteSpeed = 500;

    public GameObject meteorite;

    private float spawnTimer;
    private float width;
    private float height;
    protected int totalMeteorsToSpawn = 0;

    private List<GameObject> players;

    protected void Start()
    {
        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        width = cont.GetComponent<boundary_script>().width;
        height = cont.GetComponent<boundary_script>().height;
        players = new List<GameObject>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) players.Add(player);
        StartCoroutine(SpawnMeteorite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected IEnumerator SpawnMeteorite()
    {
        int meteorsSpawned = 0;
        while (totalMeteorsToSpawn == 0 || meteorsSpawned++ < totalMeteorsToSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            int edge = Random.Range(0, 4);
            float posX, posY;

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
            newMet.GetComponent<Rigidbody2D>().AddForce(meteoriteSpeed * direction / direction.magnitude);
        }
    }
}