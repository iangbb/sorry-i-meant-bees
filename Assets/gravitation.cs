using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    GameObject player;
    GameObject[] entities;
    Vector2 velocity = new Vector2(0,0);

    // Start is called before the first frame update
    void Start() {
        player = gameObject;
        entities = UnityEngine.Object.FindObjectsOfType<GameObject>();
    }
      
    // Update is called once per frame
    void Update() {
        Vector2[] components = new Vector2[entities.Length];
        for (int i = 0; i < components.Length; i++) {
            if (entities[i] == player) {
                    continue;
            }
            Vector2 entity_vector = entities[i].GetComponent<Transform>().position;
            Vector2 player_vector = player.GetComponent<Transform>().position;
            Vector2 separation_vector = entity_vector - player_vector;
            float player_mass = player.GetComponent<Rigidbody2D>().mass;
            float other_mass = entities[i].GetComponent<Rigidbody2D>().mass;
            components[i] = Acceleration(player_mass, other_mass, separation_vector);
            velocity = FindResultant(components);
        }
        
    }

    Vector2 Acceleration(float m, float M, Vector2 r_vector) {
        float G = 1;
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
