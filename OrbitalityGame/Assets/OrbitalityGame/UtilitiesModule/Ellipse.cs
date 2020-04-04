using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.UtilitiesModule
{
    [RequireComponent(typeof(LineRenderer))]
    public class Ellipse
    {
        public LineRenderer lineRend;

        //[Range(3, 36)]
        //public int segments;
        //public float xAxis = 5f;
        //public float yAxis = 3f;
        
        public Vector3[] GetEllipsePositions(int segments, float xAxis, float yAxis)
        {
            Vector3[] points = new Vector3[segments + 1];
            for (int i = 0; i < segments; i++)
            {
                float angle = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
                float x = Mathf.Sin(angle) * xAxis;
                float y = Mathf.Cos(angle) * yAxis;
                points[i] = new Vector3(x, 0f, y);
            }
            points[segments] = points[0];
            return points;
        }


        //public void CalculateElipse()
        //{
        //    Vector3[] points = new Vector3[segments + 1];
        //    for (int i = 0; i < segments; i++)
        //    {
        //        float angle = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
        //        float x = Mathf.Sin(angle) * xAxis;
        //        float y = Mathf.Cos(angle) * yAxis;
        //        points[i] = new Vector3(x, 0f, y);
        //    }
        //    points[segments] = points[0];

        //    lineRend.positionCount = segments + 1;
        //    lineRend.SetPositions(points);
        //}

        //private void OnValidate()
        //{
        //    CalculateElipse();
        //}
    }
}

