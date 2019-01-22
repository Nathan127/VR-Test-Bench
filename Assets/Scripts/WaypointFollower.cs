using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public GameObject[] waypointsA;
    public GameObject[] waypointsB;
    public int num01 = 0;
    public int num02 = 0;
    public float minDist;
    public float speed;
    public bool rand = false;
    public bool go = true;
    public bool switcher = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(switcher)
        {
            float dist = Vector3.Distance(gameObject.transform.position, waypointsA[num01].transform.position);
            Goer(dist, waypointsA, num01);
        }
        else
        {
            float dist = Vector3.Distance(gameObject.transform.position, waypointsB[num02].transform.position);
            Goer(dist, waypointsB, num02);
        }
        
	}

    public void Move(int num, GameObject[] array)
    {
        gameObject.transform.LookAt(array[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }

    public void Goer(float dist, GameObject[] array, int num)
    {
        if (go)
        {
            if (dist > minDist)
            {
                Move(num, array);
            }
            else
            {
                if (!rand)
                {
                    if (num + 1 == array.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num = Random.Range(0, array.Length);
                }
            }
        }
    }
}
