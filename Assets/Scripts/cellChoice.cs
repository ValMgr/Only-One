using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cellChoice : MonoBehaviour {

    [System.NonSerialized]
    private int ID;
    private Renderer CellRenderer;
    private GameManager GameManager;

    
    private void Start() {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CellRenderer = this.gameObject.GetComponent<Renderer>();
    }

    public void SetID(int id){
        ID = id;
    }

    private Color prevColor;
    private Color newColor;

    // on mouse over highlight cell
    private void OnMouseOver() {
        if(CellRenderer.material.color != newColor){
            prevColor = CellRenderer.material.color;
        }
        newColor = prevColor + new Color(0.15f, 0.15f, 0.15f, prevColor.a + 0.3f);
        CellRenderer.material.SetColor("_Color", newColor);
    }

    // on mouse exit reset cell color
    private void OnMouseExit() {
        CellRenderer.material.SetColor("_Color", prevColor /*new Color(1f, 1f, 1f, 0.45f)*/);
    }

    // when clicked call function in GameManager.cs
    public void OnMouseDown() {
        GameManager.CellClicked(this.ID, this.transform.position);
    }
}