using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDrawLine : MonoBehaviour {

    private LineRenderer lr;
    private float counter;
    private float dist;

    private Vector3 startPos, endPos;

    Material lineMat;

    public float lineDrawSpeed = 6f; // 클수록 느려짐.

    void Start () {
        startPos = GameObject.Find("Cube1").GetComponent<Transform>().position;
        endPos = GameObject.Find("Cube2").GetComponent<Transform>().position;

        lineMat = Resources.Load("red", typeof(Material)) as Material;

        lr = createLine();

        dist = Vector3.Distance(startPos, endPos);

        lr.SetPosition(0, startPos);
    }
	
	
	void Update () {
		if(counter < dist)
        {
            counter += .1f / lineDrawSpeed;

            float x = Mathf.Lerp(0, dist, counter);
                       
            Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;

            lr.SetPosition(1, pointAlongLine);
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
