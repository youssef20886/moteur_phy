using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Translation : MonoBehaviour
{
    /*
    public GameObject waypoints;
    public float vmax;
    int i;
    GameObject a;
    GameObject b;
    Vector3 v;
    Vector3 p;
    Vector3 direction;
    public float margeDeCollision;


    void Start()
    {
        i = 0;
        a = waypoints.transform.GetChild(i).gameObject;
        b = waypoints.transform.GetChild(i + 1).gameObject;
    }

    void Update()
    {

        TranslationHandler();

    }
    public void TranslationHandler()
    {
        direction = b.transform.position - a.transform.position;
        direction.z = 0;
        v = direction.normalized;
        p = transform.position;
        p += v * vmax * Time.deltaTime;

        transform.position = p;

        if (Math.Abs(Vector3.Distance(b.transform.position, p)) < margeDeCollision)
        {
            //Debug.Log((Vector3.Distance(b.transform.position, p)));
            if ((i <= waypoints.transform.childCount - 2))
            {
                Debug.Log(i);
                a = waypoints.transform.GetChild(i).gameObject;
                b = waypoints.transform.GetChild(i + 1).gameObject;

            }
            else
            {

                a = waypoints.transform.GetChild(waypoints.transform.childCount - 1).gameObject;
                b = waypoints.transform.GetChild(0).gameObject;
                i = -1;
            }
            i++;
            RotationHandler();
        }
    }

    public void RotationHandler()
    {


        Vector3 myDirection = (b.transform.position - transform.position);
        var angle = Mathf.Atan2(myDirection.y, myDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);


        transform.rotation = rotation;
    }*/
}
