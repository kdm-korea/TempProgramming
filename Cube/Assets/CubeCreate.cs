using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreate : MonoBehaviour
{

    private GameObject[] cubeBox;
    private GameObject[] cubeVertical;
    private GameObject userRotate;

    void Start() {
        userRotate = new GameObject("User");
        userRotate.AddComponent<BoxCollider>();

        userRotate.transform.position = Vector3.zero;
        userRotate.transform.localScale = new Vector3(3, 0.2f, 3);

        CreateCube();

        TieCube(cubeBox, cubeBox[4]);

        cubeVertical = new GameObject[]{
            cubeBox[0], cubeBox[1], cubeBox[2],
            cubeBox[9], cubeBox[10], cubeBox[11],
            cubeBox[18], cubeBox[19], cubeBox[20],
        };
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            UntieCube(cubeBox);
        }
        else if (Input.GetKey(KeyCode.A)) {
            TieCube(cubeVertical, cubeBox[10]);
        }
        else if (Input.GetKey(KeyCode.B)) {
            TieCube(cubeBox, cubeBox[4]);
        }
    }

    private void OnCollisionEnter(Collision col) {
        
    }

    private void CreateCube() {
        cubeBox = new GameObject[28];
        int col = 0, row = 0, dept = 0;

        for (int idx = 0; idx < 27; idx++) {
            cubeBox[idx] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (idx % 3 == 0) {
                row = 0;
                col++;
            }
            if (idx % 9 == 0) {
                col = 0;
                row = 0;
                dept++;
            }
            cubeBox[idx].transform.position = new Vector3(row, col, dept);
            cubeBox[idx].name = $"cubeBox{idx}";
            row++;
        }
    }

    private void TieCube(GameObject[] cube, GameObject pivotCube) {
        for (int idx = 0; idx < 9; idx++) {
            if (!pivotCube.Equals(cube[idx])) {
                cube[idx].transform.parent = pivotCube.transform;
            }
        }
    }

    private bool TieCube(GameObject pivotCube) {


        return false;
    }

    private void UntieCube(GameObject[] cube) {
        for (int idx = 0; idx < 27; idx++) {
            cube[idx].transform.parent = null;
        }
    }
}
