using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cellChoice : MonoBehaviour {

    [System.NonSerialized]
    public int ID;
    private Renderer CellRenderer;
    
    private void Start() {
        CellRenderer = this.gameObject.GetComponent<Renderer>();
    }
    
    private void OnMouseOver() {
        CellRenderer.material.SetColor("_Color", Color.blue);
    }

    private void OnMouseExit() {
        CellRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.4313726f));
    }

    private void OnMouseDown() {
        Debug.Log(ID);
    }
}