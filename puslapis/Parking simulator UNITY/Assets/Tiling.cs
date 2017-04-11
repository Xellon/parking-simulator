using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiling : MonoBehaviour {
    //Major lag
    public GameObject car;
    public GameObject tile;

    private class Tile {
        Vector3 pos = new Vector3(0, 0, 0);
        bool loaded = false;

        public Tile(Vector3 position) {
            pos = position;
        }

        public void checkDistance(Transform car, GameObject tile) {
            if ((car.transform.position - pos).magnitude < 30 && !loaded) {
                Instantiate(tile, pos, Quaternion.identity);
                Debug.Log("Trying");
                loaded = true;
            }
            Debug.Log("Missing");
        }
    };

    Tile[,] tile_array;

    private float delta_time = 0.0f;

	// Use this for initialization
	void Start () {
        tile_array = new Tile[100,100];

        for (int i = 0; i < 100; i++) {
            for (int j = 0; j < 100; j++) {
                tile_array[i, j] = new Tile(new Vector3(i, -0.1f, j));
            }
        }

        car = GameObject.FindGameObjectWithTag("PlayerCar");
        tile = GameObject.Find("Tile");
    }
	
	// Update is called once per frame
	void Update () {
        delta_time += Variables.delta_t;
        if (delta_time > 1) {
            delta_time = 0;

            for (int i = 0; i < 100; i++) {
                for (int j = 0; j < 100; j++) {
                    tile_array[i, j].checkDistance(car.transform, tile);
                }
            }
        }
	}

}
