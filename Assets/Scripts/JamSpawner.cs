using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamSpawner : MonoBehaviour
{
    public float minSpawnInterval = 3;
    public float maxSpawnInterval = 4;

    public List<GameObject> jams;

    private float width;
    private float height;
    private GameObject tel;

    void Start()
    {
        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        width = cont.GetComponent<boundary_script>().width;
        height = cont.GetComponent<boundary_script>().height;
        StartCoroutine(SpawnJams());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnJams()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            float posX = Random.Range(-width / 2, width / 2);
            float posY = Random.Range(-height / 2, height / 2);
            GameObject jam = jams[Random.Range(0, jams.Count)];
            GameObject newJam = Instantiate(jam, new Vector2(posX, posY), new Quaternion());

        }
    }
}
