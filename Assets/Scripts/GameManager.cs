using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject Camera;
    public List<GameObject> Characters;

    private void Start() {
        for(int i = 0; i < GameObject.Find("Characters").transform.childCount; i++){
            Characters.Add(GameObject.Find("Characters").transform.GetChild(i).gameObject);
        }
    }

    private void Update() {
        
    }

    private int lastID;
    private Vector3 lastCellPos;
    public void CellClicked(int ID, Vector3 Pos){
        lastID = ID;
        lastCellPos = Pos;
        Action();
    }

    private void Action(){
        foreach (var el in Characters){
            if(el.GetComponent<Characters>().mooving){
                el.GetComponent<Characters>().Moove(lastCellPos);
            }
        }

    }
    
}