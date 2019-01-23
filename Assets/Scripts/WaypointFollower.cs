using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public GameObject[] waypointsA;
    public GameObject[] waypointsB;
    public int num01 = 0;
    public int num02 = 0;
    public float minDist01 = 0.1f;
    public float minDist02 = 0.1f;
    public float speed;
    public bool go = true;
    public bool switcher = false;

	// Use this for initialization
	void Start ()
    {
        minDist01 = 0.1f;
        minDist02 = 0.1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(go)
        {
            if (!switcher)
            {
                float dist = Vector3.Distance(gameObject.transform.position, waypointsA[num01].transform.position);
                if(dist > minDist01)
                {
                    Move();
                }
                else
                {
                    if(num01 + 1 == waypointsA.Length)
                    {
                        //num01 = 0;
                        go = false;
                    }
                    else
                    {
                        num01++;
                    }
                }
            }
            else
            {
                float dist = Vector3.Distance(gameObject.transform.position, waypointsB[num02].transform.position);
                if (dist > minDist02)
                {
                    Move();
                }
                else
                {
                    if (num02 + 1 == waypointsB.Length)
                    {
                        //num02 = 0;
                        go = false;
                    }
                    else
                    {
                        num02++;
                    }
                }
            }
        }
	}

    public void Move()
    {
        if(!switcher)
        {
            gameObject.transform.LookAt(waypointsA[num01].transform.position);
            gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        }
        else
        {
            gameObject.transform.LookAt(waypointsB[num02].transform.position);
            gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        }
    }
}
