using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject Camera;
    public List<GameObject> Characters;

    private void Start() {

        // Add all Characters present in the scene to the 'Character' array
        for(int i = 0; i < GameObject.Find("Characters").transform.childCount; i++){
            Characters.Add(GameObject.Find("Characters").transform.GetChild(i).gameObject);
        }

        
    }
    private int lastID;
    private Vector3 lastCellPos;

    // When a cell is clicked, get the ID and Pos and call Action()
    public void CellClicked(int ID, Vector3 Pos){
        lastID = ID;
        lastCellPos = Pos;
        Action();
    }

    // -- can only move atm
    // Check every characters to found which one is playing to launch action
    private void Action(){
        foreach (var el in Characters){
            if(el.GetComponent<Characters>().mooving){
                el.GetComponent<Characters>().Moove(lastCellPos);
            }
        }

    }
    
}