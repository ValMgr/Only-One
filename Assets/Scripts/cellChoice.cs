using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cellChoice : MonoBehaviour {

    [System.NonSerialized]
    public int ID;
    public bool selected;
    private Renderer CellRenderer;

    private List characters;
    
    private void Start() {
        Debug.Log(GameObject.Find("Characters").transform.GetChild(0));
        CellRenderer = this.gameObject.GetComponent<Renderer>();
    }

    private Color prevColor;
    private Color newColor;
    
    private void OnMouseOver() {
        if(CellRenderer.material.color != newColor){
            prevColor = CellRenderer.material.color;
        }
        newColor = prevColor + new Color(0.3f, 0.3f, 0.3f, prevColor.a + 0.3f);
        CellRenderer.material.SetColor("_Color", newColor);
        selected = true;
    }

    private void OnMouseExit() {
        CellRenderer.material.SetColor("_Color", prevColor /*new Color(1f, 1f, 1f, 0.45f)*/);
        selected = false;
    }

    public void OnMouseDown() {
       //characters.gameObject.SendMessage("Moove", this.transform.position /*,SendMessageOptions.DontRequireReceiver*/);
    }
}