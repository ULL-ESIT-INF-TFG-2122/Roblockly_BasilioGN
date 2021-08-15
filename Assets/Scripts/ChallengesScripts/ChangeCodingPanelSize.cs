using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCodingPanelSize : MonoBehaviour
{
    private Transform codingPanel;
    // Start is called before the first frame update
    void Start()
    {
        codingPanel = GameObject.Find("Workspace/CodingPanel").GetComponent<Transform>();
    }

    public void MaximizeCodingPanel()
    {
        if(codingPanel.localScale.x < 1.33f){
            codingPanel.localScale += new Vector3(0.11f, 0.11f, 0);
        }
    }

    public void MinimizeCodingPanel()
    {
        if(codingPanel.localScale.x > 0.66f){
            codingPanel.localScale -= new Vector3(0.11f, 0.11f, 0);
        } 
    }
}
