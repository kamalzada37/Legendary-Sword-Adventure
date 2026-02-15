using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing_projectiles : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 15f;
    public float maxProjectileDistance = 3f;

    // SHOOT SOUND
    public AudioClip shootSfx;
    private AudioSource audioSource;

    private character_movement characterMovementScriptReference;

    // Getting a reference to the blue chief bird GameObject
    public string chief_bird_name = "blue bird sprite_0";
    public GameObject chief_bird;
    private chief_NPC_interaction chief_NPC_interaction_script_reference;

    void Start()
    {
        chief_bird = GameObject.Find(chief_bird_name);
        characterMovementScriptReference = GetComponent<character_movement>();

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
        chief_NPC_interaction chief_NPC_interaction_script_reference = chief_bird.GetComponent<chief_NPC_interaction>();

        if (Input.GetKeyDown(KeyCode.S) && chief_NPC_interaction_script_reference.completedinteraction == true)
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // play shoot sound
        if (shootSfx != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSfx);
        }

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Setting all the projectile clones to be of a higher sorting order (by default this is 0)
        SpriteRenderer projectileRenderer = projectile.GetComponent<SpriteRenderer>();
        if (projectileRenderer != null)
        {
            projectileRenderer.sortingOrder = 6;
        }

        projectile.tag = "arrow";

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        BoxCollider2D projectileBc = projectile.GetComponent<BoxCollider2D>();

        if (projectileRb == null)
        {
            projectileRb = projectile.AddComponent<Rigidbody2D>();
        }

        if (projectileBc == null)
        {
            projectileBc = projectile.AddComponent<BoxCollider2D>();
        }

        // Ignore collision of character sprite with each arrow GameObject
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");

        foreach (GameObject arrow in arrows)
        {
            BoxCollider2D myCol = gameObject.GetComponent<BoxCollider2D>();
            BoxCollider2D arrowCol = arrow.GetComponent<BoxCollider2D>();

            if (myCol != null && arrowCol != null)
            {
                Physics2D.IgnoreCollision(myCol, arrowCol, true);
            }
        }

        if (characterMovementScriptReference.isfacingright == true)
        {
            projectileRb.linearVelocity = transform.right * (transform.localScale.x > 0 ? projectileSpeed : -projectileSpeed);
        }
        else
        {
            projectileRb.linearVelocity = -transform.right * (transform.localScale.x > 0 ? projectileSpeed : -projectileSpeed);

            if (projectileRenderer != null)
            {
                projectileRenderer.flipX = true;
            }
        }

        StartCoroutine(DestroyProjectileAfterDistance(projectile));
    }

    IEnumerator DestroyProjectileAfterDistance(GameObject projectile)
    {
        float traveledDistance = 0f;

        while (traveledDistance < maxProjectileDistance)
        {
            traveledDistance += projectileSpeed * Time.deltaTime;
            yield return null;
        }

        Destroy(projectile);
    }
}
