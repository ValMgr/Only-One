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

    // When level start, draw grid by instatiate as many cells needed to fill x & y length
    private void Grid(int x, int y){

        int id = 0;

        float xf = (float)x;
        float yf = (float)y;

        // Run through x Axis until xLength reached
        for (int i = 0; i < xLength; i++){
            // Run through y Axis until yLength reached
            for(int j = 0; j < yLength; j++){

                // Multiply current position per 4 to accord to cells size (here 4)
                int posX = i * 4;
                int posY = j * 4;

                GameObject cells = Instantiate(cell, new Vector3(posX - xf * 2, 0f, posY - yf * 2), Quaternion.identity);
                cells.transform.localScale = cell.transform.localScale + new Vector3(-0.1f, 0, -0.1f);
                
                // Attach each cell with 'Map' GameObject as parent
                cells.transform.parent = Map.transform;
                // Add name and tag and assign correct ID
                cells.name = "cell" + id;
                cells.tag = "Cells";
                cells.GetComponent<cellChoice>().SetID(id);
                id++;
                
            }
        }
    }

 
}