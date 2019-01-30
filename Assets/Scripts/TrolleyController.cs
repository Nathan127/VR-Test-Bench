using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class TrolleyController : MonoBehaviour
    {
        public GameObject[] waypointsA;
        public GameObject[] waypointsB;
        public int num01 = 0;
        public int num02 = 0;
        public float minDist01 = 0.5f;
        public float minDist02 = 0.5f;
        public float speed = 2;
        public bool go = false;
        public bool switcher = false;
        public bool disable_switch = false;
        bool checker = false;
        public LinearMapping linearMapping;
        private float currentLinearMapping = float.NaN;

        // Use this for initialization
        void Start()
        {
            minDist01 = 0.5f;
            minDist02 = 0.5f;
            speed = 2;

            if (linearMapping == null)
            {
                linearMapping = GetComponent<LinearMapping>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (go == true)
            {
                float dist01 = Vector3.Distance(gameObject.transform.position, waypointsA[num01].transform.position);
                if (dist01 > minDist01)
                {
                    Move();
                }
                else
                {
                    if (num01 + 1 == waypointsA.Length)
                    {
                        //num01 = 0;
                        go = false;
                    }
                    else
                    {
                        num01++;
                    }
                }

                if (switcher && !disable_switch)
                {
                    float dist02 = Vector3.Distance(gameObject.transform.position, waypointsB[num02].transform.position);
                    if (dist02 > minDist02)
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

            if (num01 >= 2 && !switcher)
            {
                disable_switch = true;
            }
            if (switcher && num02 >= 1)
            {
                checker = true;
            }

            if (currentLinearMapping != linearMapping.value)
            {
                currentLinearMapping = linearMapping.value;
            }

            if(currentLinearMapping > 0.2)
            {
                go = true;
            }

            if(currentLinearMapping >= 0.5)
            {
                switcher = true;
            }
        }

        public void Move()
        {
            if (switcher && !disable_switch)
            {
                gameObject.transform.LookAt(waypointsB[num02].transform.position);
                gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
            }
            else if (disable_switch && checker)
            {
                gameObject.transform.LookAt(waypointsB[num02].transform.position);
                gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
            }
            else
            {
                gameObject.transform.LookAt(waypointsA[num01].transform.position);
                gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
            }
        }
    }
}
