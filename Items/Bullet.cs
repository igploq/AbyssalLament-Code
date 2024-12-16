using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
            else
            {
                Spawner spawner = collision.gameObject.GetComponent<Spawner>();
                if (spawner != null)
                {
                    spawner.TakeDamage(bulletDamage);
                }
            }

            

            Destroy(gameObject);
        }
    }
}
