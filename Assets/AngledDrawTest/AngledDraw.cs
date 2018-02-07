using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngledDraw : MonoBehaviour {

    public Transform point1;
    public Transform point2;
    public LineRenderer lr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!point1 || !point2 || !lr)
        {
            return;
        }

        //lr.SetPositions(new Vector3[] { point1.position, point2.position });

        lr.positionCount = 4;
        lr.SetPositions(DrawCorneredAngle(point1.position, point2.position));
	}

    Vector3[] DrawCorneredAngle(Vector3 point1, Vector3 point2)
    {
        float xDiff = point1.x - point2.x;
        float yDiff = point1.y - point2.y;
                
        Vector3 point1Up = point1;
        Vector3 point2Up = point2;

        Vector3 middle = (point1 +  point2) / 2;

        //Debug.Log("xDiff " + xDiff + ", yDiff " + yDiff);
                
        if (Mathf.Abs(xDiff) < Mathf.Abs(yDiff))
        {
            // x less than y
            float halfDiff = xDiff / 2.0f;

            // 참고 90도
            //point1Up = new Vector3(point1.x, middle.y, point1.z);
            //point2Up = new Vector3(point2.x, middle.y, point2.z);


            // halfDiff 부호있는 값이므로 절대값을 취해서 계산해야 함.
            // middle값을 기준으로 각 포지션이 middle값보다 위에 있을지 아래 있을지 고려해야 함.
            if (point1.y < point2.y)
            {
                // |        p2
                // |        p2up
                //  \              middle 기준으로 p1up은 아래이므로 -, p2up은 위이므로 +
                //   |      p1up
                //   |      p1

                point1Up = new Vector3(point1.x, middle.y - Mathf.Abs(halfDiff), point1.z);
                point2Up = new Vector3(point2.x, middle.y + Mathf.Abs(halfDiff), point2.z);
            }
            else
            {
                // |        p1
                // |        p1up
                //  \               middle 기준으로 p2up은 아래이므로 -, p1up은 위 이므로 +
                //   |      p2up
                //   |      p2

                point1Up = new Vector3(point1.x, middle.y + Mathf.Abs(halfDiff), point1.z);
                point2Up = new Vector3(point2.x, middle.y - Mathf.Abs(halfDiff), point2.z);
            }
        }
        else
        {
            // y less than x
            var halfDiff = yDiff / 2;

            // 참고 90도
            //point1Up = new Vector3(middle.x, point1.y, point1.z);
            //point2Up = new Vector3(middle.x, point2.y, point2.z);

            if (point1.x < point2.x)
            {
                // p1 p1up
                // ----
                //      \       middle 기준으로 p1up은 왼쪽에 있으므로 -, p2up은 오른쪽에 있으므로 +
                //       ----
                //       p2up  p2


                point1Up = new Vector3(middle.x - Mathf.Abs(halfDiff), point1.y, point1.z);
                point2Up = new Vector3(middle.x + Mathf.Abs(halfDiff), point2.y, point2.z);
            }
            else
            {
                // p2 p2up
                // ----
                //      \       middle 기준으로 p2up은 왼쪽에 있으므로 -, p1up은 오른쪽에 있으므로 +
                //       ----
                //       p1up  p1

                point1Up = new Vector3(middle.x + Mathf.Abs(halfDiff), point1.y, point1.z);
                point2Up = new Vector3(middle.x - Mathf.Abs(halfDiff), point2.y, point2.z);
            }
            
        }

        return new Vector3[] { point1, point1Up, point2Up, point2 };
    }
}
