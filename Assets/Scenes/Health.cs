using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    // Custom delegate for the event
    public event Action<int> DecreaseHealthEvent;

    public void DecreaseHealth(int healthDecrease)
    {
        // Trigger the event, passing the health decrease value
        DecreaseHealthEvent?.Invoke(healthDecrease);

        // (Optional) Check for health depletion after subscribers modify it
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeHealth(int newHealth)
    {
        health = newHealth;
        Debug.Log($"Health has been updated! New health: {health}");
    }
}
