using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    
    public GameObject[] blocks;
    
    public Vector2 offset;

    public int sizeX;
    public int sizeY;

    int[][] field;
    GameObject[][] fieldObjects;
    
    Vector3 lastMousePos;

    // Start is called before the first frame update
    void Start() {
        field = new int[sizeY][];
        fieldObjects = new GameObject[sizeY][];

        for (int y = 0; y < field.Length; y++) {
            field[y] = new int[sizeX];
            fieldObjects[y] = new GameObject[sizeX];

            for (int x = 0; x < field[y].Length; x++) {

                // Setze Stein an Stelle x, y.
                if (y == sizeY - 1) {
                    field[y][x] = 0;
                } else {
                    field[y][x] = 1;
                }

                if (field[y][x] >= 0) {
                    fieldObjects[y][x] = Instantiate(blocks[field[y][x]], new Vector3(x - offset.x, y - offset.y, 0), Quaternion.identity);
                }
            }
        }
    }

    void Update() {
        Vector3 coordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            int x = (int)Mathf.Round(coordinate.x + offset.x);
            int y = (int)Mathf.Round(coordinate.y + offset.y);

            Debug.Log(x + ", " +  y);

            lastMousePos = coordinate;
            if (x >= 0 && x < sizeX && y >= 0 && y < sizeY) {
                field[y][x] = -1;
                Destroy(fieldObjects[y][x]);
                
            }
        }

        if (Input.GetMouseButton(0)) {
            Vector2 delta = lastMousePos - coordinate;
            Camera.main.transform.position += (Vector3)delta;
            
            coordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePos = coordinate;
        }
    }

}