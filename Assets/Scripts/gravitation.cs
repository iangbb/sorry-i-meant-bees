using UnityEngine;

public class gravitation : MonoBehaviour {
    GameObject player;
    GameObject[] entities;
    Vector2 velocity = new Vector2(0,0);
    public float G = 100;

    // Start is called before the first frame update
    void Start() {
        player = gameObject;
        entities = FindObjectsOfType<GameObject>();
        Debug.Log("entity 1 is: " + entities[0]);
        Debug.Log("entity 2 is: " + entities[1]);
        Debug.Log("entity 3 is: " + entities[2]);
        Debug.Log("entity 4 is: " + entities[3]);
        Debug.Log("entity 5 is: " + entities[4]);
        Debug.Log("entity 6 is: " + entities[5]);
        Debug.Log("entity 7 is: " + entities[6]);

    }
      
    // Update is called once per frame
    void Update() {
        Debug.Log("hello");
        Vector2[] components = new Vector2[entities.Length];
        for (int i = 0; i < components.Length; i++) {
            Debug.Log("entity "+i+ " is" + entities[i]);
            if (entities[i] == player || entities[i].GetComponent<info>() == null) {
                Debug.Log("player? is" + entities[i]);
                    continue;
            }
            Vector2 entity_vector = entities[i].GetComponent<Transform>().position;
            Vector2 player_vector = player.GetComponent<Transform>().position;
            Vector2 separation_vector = entity_vector - player_vector;
            float player_mass = player.GetComponent<info>().mass;
            float other_mass = entities[i].GetComponent<info>().mass;
            components[i] = Acceleration(player_mass, other_mass, separation_vector);
            Debug.Log("component is: "+ components[i]);
        }
        player.GetComponent<Rigidbody2D>().velocity = FindResultant(components);
    }

    Vector2 Acceleration(float m, float M, Vector2 r_vector) {
        float r = r_vector.magnitude;
        Vector2 direction = r_vector / r;
        return direction * (G * m * M) / (r * r);
    }

    Vector2 FindResultant(Vector2[] components) {
        Vector2 resultant = new Vector2(0, 0);
        for (int i = 0; i < components.Length; i++) {
            resultant += components[i];
        }
        return resultant;
    }

}

