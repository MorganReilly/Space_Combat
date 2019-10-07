using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=XCOTK-a-1cc
public class BulletScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float deactivate_timer = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }
}
