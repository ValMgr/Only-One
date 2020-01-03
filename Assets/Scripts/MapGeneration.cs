using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MapGeneration : MonoBehaviour {
    
    public int xLength;
    public int yLength;
    public GameObject Map;
    public GameObject cell;

    private void Start() {
        Grid(xLength, yLength);
    }

    private void Grid(int x, int y){

        int id = 0;

        float xf = (float)x;
        float yf = (float)y;

        for (int i = 0; i < xLength; i++){
            for(int j = 0; j < yLength; j++){

                int posX = i * 4;
                int posY = j * 4;

                GameObject cells = Instantiate(cell, new Vector3(posX - xf * 2, 0f, posY - yf * 2), Quaternion.identity);
                cells.transform.localScale = cell.transform.localScale + new Vector3(-0.1f, 0, -0.1f);
                cells.transform.parent = Map.transform;
                cells.name = "cell" + id;
                cells.tag = "Cells";

                cells.GetComponent<cellChoice>().SetID(id);
                id++;
                
            }
        }
    }

 
}