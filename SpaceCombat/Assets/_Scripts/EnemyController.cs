// xusing System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables
    public float speed = 5.0f;

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
        // Find temp location then subtract from it to
        // allow enemy movement 
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }
}