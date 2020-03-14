using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] lines;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject cur in lines)
        {

            float distance;
            RaycastHit hit;
            if (Physics.Raycast(cur.transform.position, cur.transform.forward, out hit, 1000.0f))
            {
                distance = hit.distance;
                if (hit.transform.gameObject.GetComponent<Character>() != null)
                {
                    hit.transform.gameObject.GetComponent<Character>().ChangeHealth(-1000);
                }

            }
            else distance = 1000.0f;
            cur.transform.localScale = new Vector3(1, 1, distance);

        }

    }
}
