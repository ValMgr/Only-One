using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cellChoice : MonoBehaviour {

    [System.NonSerialized]
    public int ID;
    public bool canClick = false;
    private Renderer CellRenderer;
    
    private void Start() {
        CellRenderer = this.gameObject.GetComponent<Renderer>();
    }

    private Color prevColor;
    
    private void OnMouseOver() {
        if(CellRenderer.material.color != Color.blue){
            prevColor = CellRenderer.material.color;
        }
        CellRenderer.material.SetColor("_Color", Color.blue);
    }

    private void OnMouseExit() {
        CellRenderer.material.SetColor("_Color", prevColor /*new Color(1f, 1f, 1f, 0.45f)*/);
    }

    public void OnMouseDown() {
        if(canClick){
            
        }
    }
}