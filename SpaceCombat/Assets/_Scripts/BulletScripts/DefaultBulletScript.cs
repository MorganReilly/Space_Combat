using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBulletScript : MonoBehaviour
{
    // Variables
    public float speed = 5.0f; // Bullet Speed
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
