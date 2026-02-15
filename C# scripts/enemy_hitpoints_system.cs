using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hitpoints_system : MonoBehaviour
{
    public int hitpoints = 3;

    // DEATH SOUND
    public AudioClip deathSfx;
    private AudioSource audioSource;

    private bool isDead = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // auto-add so it works even if you forgot
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f; // 2D sound
        }
    }

    void Update()
    {
        if (hitpoints <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("An enemy is killed!");

            if (deathSfx != null && audioSource != null)
            {
                audioSource.PlayOneShot(deathSfx);
                Destroy(gameObject, 0.25f); // small delay so sound starts
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("arrow"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        hitpoints--;
        Debug.Log("An enemy took damage!");
    }
}
