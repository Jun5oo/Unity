using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Worm : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform target;
    public float rotationSpeed;
    private Vector2 direction; 

    void Start()
    {
        rb = this.gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); 
    }


}
