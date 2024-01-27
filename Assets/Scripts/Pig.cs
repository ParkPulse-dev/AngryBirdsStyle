using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour
{
    // Health of the pig
    public float Health = 100f;

    // Sprite to show when the pig's health is below a certain threshold
    public Sprite SpriteShownWhenHurt;

    // Health threshold to change sprite
    private float ChangeSpriteHealth;

    // Damage multiplier
    private const float DamageMultiplier = 30f;

    void Start()
    {
        // Calculate the health threshold to change sprite
        ChangeSpriteHealth = Health - (DamageMultiplier / 3f); // Assuming you want to subtract 1/3 of DamageMultiplier
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the colliding object has a Rigidbody2D component
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        // Check if the colliding object is a bird
        if (col.gameObject.tag == "bird")
        {
            // Destroy the pig if hit by a bird
            Destroy(gameObject);
        }
        else
        {
            // Calculate damage based on the velocity of the colliding object
            float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * DamageMultiplier;

            // Reduce pig's health by the calculated damage
            Health -= damage;

            // Change sprite if health is below the threshold
            if (Health < ChangeSpriteHealth)
            {
                GetComponent<SpriteRenderer>().sprite = SpriteShownWhenHurt;
            }

            // Destroy the pig if its health is depleted
            if (Health <= 0) Destroy(this.gameObject);
        }
    }
}
