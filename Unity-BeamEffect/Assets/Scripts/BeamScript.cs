using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    public Camera cam;
    public GameObject firePoint;
    public LineRenderer lr;
    public float maximumLength;

    private int points;
    private GameObject point2;

    private int numPoints = 50;
    private Vector3[] positions = new Vector3[50];


    // Start is called before the first frame update
    void Start()
    {
        lr.positionCount = numPoints;        
    }

    // Update is called once per frame
    void Update()
    {
        float segmentWidth = 0.3f;

        Transform point1 = firePoint.transform;
        /*      
        Transform point1 = firePoint.transform;
        Transform point3 = ;

        DrawQuadraticCurve(point1);*/

        if (Input.GetMouseButton(0))
        {
            //lr.SetPosition(0, firePoint.transform.position);
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            var rayMouse = cam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLength))
            {
                //If raycast hits an object.
                //Needs to be changed to deer and wolf in game.
                if (hit.collider)
                {                    
                    Transform point3 = hit.transform;
                    //point2 = new GameObject();
                    //Gives the newly created point2 objects a tag so they can be easily deleted. 
                    //point2.gameObject.tag = "Destruction";

                    //point2.transform.position = point3.position - point1.position;

                    //DrawQuadraticCurve(point1, point2, point3);


                    //Sine Wave
                    //https://www.youtube.com/watch?v=aAGkn0ETFX4
                    //More
                    //https://stackoverflow.com/questions/56583719/how-to-draw-a-sine-wave-using-line-renderer-from-point-a-to-point-b
                    //https://www.youtube.com/watch?v=pEXdTLsEAjk
                    for (int i = 1; i < numPoints - 1; i++)
                    {
                        float x = segmentWidth * i;
                        float y = Mathf.Sin(Time.time + i);
                        lr.SetPosition(i, new Vector3(y, 0f,x));

                    }
                    lr.SetPosition(0, firePoint.transform.position);
                    lr.SetPosition((numPoints - 1), hit.point);

                    /*
                    for (int p = 1; p <= points - 2; p++)
                    {
                        float t = p / (float)numPoints;
                    
                        positions[p - 1] = CalculateLinearBezierPoint(t, point1.position, point2.position);
                        Debug.Log(positions[p]);
                        //lr.SetPosition(p, (hit.point - firePoint.transform.position));
                    }
                    lr.SetPositions(positions);
                    /*
                    lr.SetPosition(1, (hit.point - ));*/
                    //lr.SetPosition(numPoints - 1, hit.point);

                }
            }
            else
            {
                var pos = rayMouse.GetPoint(maximumLength);
                //lr.SetPosition(1, pos);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //Deletes game objects that are created for point2.
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Destruction");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);

            //Sets all points to 0 so they are not visable. 
            for (int dp = 0; dp <= numPoints - 1; dp++)
            {
                lr.SetPosition(dp, Vector3.zero);
            }
        }
    }
    /*
    private void DrawLinearCurve()
    {
        for (int p = 1; p <= numPoints + 1; p++)
        {
            float t = p / (float)numPoints;

            positions[p - 1] = CalculateLinearBezierPoint(t, point1.position, point2.position);
        }
        lr.SetPositions(positions);
    }*/

    //Draws the points for the laser beam to follow.
    private void DrawQuadraticCurve(Transform point1, GameObject point2, Transform point3)
    {
        for (int p = 1; p < numPoints + 1; p++)
        {
            float t = p / (float)numPoints;

            positions[p - 1] = CalculateQuadraticBezierPoint(t, point1.position, point2.transform.position, point3.position);
        }
        lr.SetPositions(positions);
    }
    /*
    private void DrawCubicBezierCurve(Transform point0, Transform point1, Transform point2, Transform point3)
    {

        //lineRenderer.positionCount = 200;
        float t = 0f;
        Vector3 B = new Vector3(0, 0, 0);
        for (int i = 1; i < lr.positionCount; i++)
        {
            B = (1 - t) * (1 - t) * (1 - t) * point0 + 3 * (1 - t) * (1 - t) *
                t * point1 + 3 * (1 - t) * t * t * point2 + t * t * t * point3;

            lr.SetPosition(i, B);
            t += (1 / (float)lr.positionCount);
        }
    }
    */

    /*
        private Vector3 CalculateLinearBezierPoint(float t, Vector3 p0, Vector3 p1)
        {
            return p0 + t * (p1 - p0);
        }*/

    //Calculates the points for the laser beam to follow.
    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }
}
