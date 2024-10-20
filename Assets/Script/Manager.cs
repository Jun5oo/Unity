using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Transform[] randomPt;
    public GameObject go; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPoint = randomPt[Random.Range(0, randomPt.Length)].transform.position;
            GameObject _go = Instantiate(go, randomPoint, Quaternion.identity);
        }
    }
}
