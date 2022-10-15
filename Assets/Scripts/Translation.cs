using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Translation : MonoBehaviour
{
    
    public GameObject waypoints;
    public float vmax;
    public float tau;
    public int i_slow;
    int i;
    GameObject b;
    Vector3 v;
    Vector3 p;
    Vector3 direction;
    Quaternion rotangle;
    public float margeDeCollision;
    bool canSlow;
    float currentV;



    void Start()
    {
        i_slow = 0;
        currentV = vmax;
        i = 0;
        b = waypoints.transform.GetChild(i).gameObject;
    }

    void Update()
    {

        TranslationHandler();
        RotationHandler();

    }
    public void TranslationHandler()
    {
        direction = b.transform.position - transform.position;
        direction.z = 0;
        v = direction.normalized;
        p = transform.position;
        if (Math.Abs(Vector3.Distance(b.transform.position, p)) < margeDeCollision)
        {
            slowDown();
            
            if ((i <= waypoints.transform.childCount - 1))
            {
                b = waypoints.transform.GetChild(i).gameObject;
            }
            else
            {
                b = waypoints.transform.GetChild(0).gameObject;
                i = -1;
            }
            i++;
        }
        else if (i_slow > 0 && waypoints.transform.GetChild(i + 1).CompareTag("End"))
        {
             i_slow = 0;
             StartCoroutine(Delay());
        }
        //Ralentissement si en zone critique
        //if (direction.magnitude <= margeDeCollision )
        //{
        //    //currentV = Mathf.Lerp(vmax/4, vmax, Time.deltaTime * 2.0f);
        //    canSlow = true;
        //}
        //else if (canSlow)
        //{
        //    //currentV = Mathf.Lerp(vmax, vmax/4, Time.deltaTime * 2.0f);
        //    canSlow = false;
        //}
        p += v * vmax * Time.deltaTime;
        transform.position = p;
    }

    public IEnumerator Delay()
    {
        Debug.Log("AAAA");
        yield return new WaitForSeconds(0.3f);
        vmax *= 3;
    }
    public void slowDown()
    {
        if (i_slow == 0)
        {
            vmax = (vmax / 3);
            i_slow++;
        }
    }

    public void RotationHandler()
    {

        float betadegree = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg - 90;
        rotangle = Quaternion.AngleAxis(betadegree, new Vector3(0, 0, 1));


        transform.rotation = Quaternion.Slerp(transform.rotation, rotangle, Time.deltaTime*3.5f);
    }
}
