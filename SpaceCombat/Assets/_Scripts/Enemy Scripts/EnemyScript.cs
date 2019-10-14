using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    // Variables
    public float speed = 3.0f;
    public float rotate_speed = 5.0f; // Used for asteroids later on

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float bound_Y = -5f; // Deactivate for memory conservation

    [SerializeField]
    private Transform attack_point;

    [SerializeField]
    private GameObject bullet_prefab;

    private Animator animator;
    private AudioSource explosionSound;

    void Awake()
    {
        animator = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
                rotate_speed *= -1f; // Clockwise / anticlock wise random rotation
            } else {
                rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
            }
        }

        if(canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Move()
    {
        if (canMove)
        {
            // Find temp location then subtract from it to
            // allow enemy movement 
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            // De-activating game object once it gets to a certain point
            if (temp.y < bound_Y)
            {
                gameObject.SetActive(false);
            }

        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_speed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bullet_prefab, attack_point.position, Quaternion.identity);
        bullet.GetComponent<DefaultBulletScript>().is_enemyBullet = true;

        if(canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }



} // class
