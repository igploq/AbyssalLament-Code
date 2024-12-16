using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    // private Animator animator;
    public int enemyDamage;
    [SerializeField] private ParticleSystem deathEffect;

    public EnemyKillManager killManager;  
    public AudioSource musicSource;       


    private void Start()
    {
        // animator = GetComponent<Animator>();

        GameObject musicObject = GameObject.FindWithTag("MusicSource");

        killManager = FindObjectOfType<EnemyKillManager>();

    }


    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            // animator.SetTrigger("DIE");
            Destroy(gameObject);

            if (killManager != null && musicSource != null)
            {
                killManager.OnEnemyKilled();
                musicSource.Play();
            }

            ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            effect.Play();

            Destroy(effect.gameObject, effect.main.duration);
        }
        /* else
        {
            animator.SetTrigger("DAMAGE");
        } */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.TakeDamage(enemyDamage);
            }
            

        }
    }
}
