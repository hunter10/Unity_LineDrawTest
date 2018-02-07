using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrawLine : MonoBehaviour
{
    List<LineRenderer> lr = new List<LineRenderer>();
    Vector3 startPos, endPos;
    Material lineMat;

    Vector3[] vectors;

    void Start () {
        startPos = GameObject.Find("Cube1").GetComponent<Transform>().position;
        endPos = GameObject.Find("Cube2").GetComponent<Transform>().position;

        lineMat = Resources.Load("red", typeof(Material)) as Material;

        vectors = new Vector3[] { new Vector3(0, 1, 0),
                                  new Vector3(2, 1, 0),
                                  new Vector3(2, 3, 0) };
        
        lr.Add(createLine());
        
    }

    // Update is called once per frame
    void Update () {
        lr[0].SetPosition(0, startPos);
        lr[0].SetPosition(1, endPos);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            lr.Add(createLine());

            lr[1].positionCount = 3;

            lr[1].SetPosition(0, vectors[0]);
            lr[1].SetPosition(1, vectors[1]);
            lr[1].SetPosition(2, vectors[2]);
        }
    }
    
    private LineRenderer createLine()
    {
        LineRenderer templr = new GameObject("Line").AddComponent<LineRenderer>();
        templr.GetComponent<Renderer>().material = lineMat;
        templr.startWidth = 0.1f;
        templr.endWidth = 0.1f;
        templr.useWorldSpace = true;

        return templr;
    }
}
