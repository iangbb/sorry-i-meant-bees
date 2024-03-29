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
    }
      
    // Update is called once per frame
    void Update() {
        Vector2[] components = new Vector2[entities.Length];
        for (int i = 0; i < components.Length; i++) {
            if (entities[i] == player || entities[i].GetComponent<info>() == null) {
                    continue;
            }
            Vector2 entity_vector = entities[i].GetComponent<Transform>().position;
            Vector2 player_vector = player.GetComponent<Transform>().position;
            Vector2 separation_vector = entity_vector - player_vector;
            float player_mass = player.GetComponent<info>().mass;
            float other_mass = entities[i].GetComponent<info>().mass;
            components[i] = Acceleration(player_mass, other_mass, separation_vector);
        }
        player.GetComponent<Rigidbody2D>().velocity += FindResultant(components);
    }

    Vector2 Acceleration(float m1, float m2, Vector2 r_vector) {
        float r = r_vector.magnitude;
        Vector2 direction = r_vector / r;
        return direction * (G * m1 * m2) / (r * r);
    }

    Vector2 FindResultant(Vector2[] components) {
        Vector2 resultant = new Vector2(0, 0);
        for (int i = 0; i < components.Length; i++) {
            resultant += components[i];
        }
        return resultant;
    }

}
