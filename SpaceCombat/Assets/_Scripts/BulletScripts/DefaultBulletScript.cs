using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* References:
 * https://www.youtube.com/watch?v=XCOTK-a-1cc
 * https://www.youtube.com/watch?v=rVSLczG1M1E
 */

public class DefaultBulletScript : MonoBehaviour
{
    public float speed = 5.0f; // Bullet Speed
    public float deactivate_timer = 3.0f;

    public float bullet_damage = 10; // Bullet damage

    [HideInInspector]
    public bool is_enemyBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        // Test if is enemy bullet
        if (is_enemyBullet)
        {
            speed *= -1f;
        }

        // Calls function after x amount of time
        Invoke("DeactivateGameObject", deactivate_timer);
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

    // Removes game objects from gameplay
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    // Destroying game object
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet" || target.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
