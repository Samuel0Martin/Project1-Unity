using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve3PointRender : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public LineRenderer lr;
    public int vertexCount = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        RaycastHit hit;
        var pointList = new List<Vector3>();
        for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
        {
            var tangentLineVerxtex1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tangentLineVerxtex2 = Vector3.Lerp(point2.position, point3.position, ratio);
            var bezierPoint = Vector3.Lerp(tangentLineVerxtex1, tangentLineVerxtex2, ratio);
            pointList.Add(bezierPoint);
        }
        lr.positionCount = pointList.Count;
        lr.SetPositions(pointList.ToArray());
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(point1.position, point2.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(point2.position, point3.position);

        Gizmos.color = Color.red;
        for(float ratio = 0.25f / vertexCount; ratio < 1; ratio += 1.0f / vertexCount)
        {
            Gizmos.DrawLine(Vector3.Lerp(point1.position, point2.position, ratio), Vector3.Lerp(point2.position, point3.position, ratio));
        }*/
        
        


    }
}
