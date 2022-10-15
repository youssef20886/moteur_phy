using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Translation1 : MonoBehaviour
{
   
    public GameObject waypoints;
    public float vmax;
    int i;
    GameObject a;
    GameObject b;
    Vector3 v;
    Vector3 p;
    Vector3 direction;
    public float margeDeCollision;
    bool b_slowDown ;
    int i_slow = 0;
    Quaternion rotangle;


    void Start()
    {
        i = 0;
        b = waypoints.transform.GetChild(i).gameObject;
    }

    void Update()
    {
        RotationHandler();
        TranslationHandler();
        

    }
    public void TranslationHandler()
    {
        //direction = b.transform.position - a.transform.position;
        direction = transform.up;
        direction.z = 0;
        v = direction.normalized;
        p = transform.position;
        p += v * vmax * Time.deltaTime;
        transform.position = p;

        if (Math.Abs(Vector3.Distance(b.transform.position, p)) < margeDeCollision)
        {
            
            slowDown();
            
            if ((i <= waypoints.transform.childCount - 1))
            {
                Debug.Log(i);
                b = waypoints.transform.GetChild(i).gameObject;

            }
            else
            {

                b = waypoints.transform.GetChild(0).gameObject;
                i = -1;
            }
            i++;
        }
        else if (i_slow > 0 && waypoints.transform.GetChild(i+1).CompareTag("End"))
        {
            i_slow = 0;
            StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        Debug.Log("AAAA");
        yield return new WaitForSeconds(1f);
        vmax *= 5;
    }

    public void RotationHandler()
    {
        Vector3 Direction = (b.transform.position - transform.position).normalized;


        float AngleRad = Mathf.Atan2(b.transform.position.y - transform.position.y, b.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        rotangle = Quaternion.AngleAxis(AngleDeg, new Vector3(0, 0, 1));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotangle, Time.deltaTime*2.0f);


        // TRASH
        //float betadegree = Vector3.Angle(transform.up, Direction)*Mathf.Rad2Deg;
        //var angle = Vector3.Angle(transform.up,Direction );      

        ////Debug.Log(angle);
        //var angleRad = -angle * Math.PI/180;

        //Quaternion q = new Quaternion(0, 0, (float)Math.Sin(angleRad / 2), 0);
        //Debug.Log(q);
        ////transform.Rotate(new Vector3(0, 0, angle));
        //transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime*2f);
        ////transform.Rotate(new Vector3(0, 0, angle));

        ////Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    public void slowDown()
    {
        if (i_slow == 0)
        {
            vmax = (vmax / 5);
            b_slowDown = false;
            i_slow++;
        }
        
    }




}
