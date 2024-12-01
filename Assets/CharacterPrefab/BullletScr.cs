using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullectScr : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.localScale.x > 0)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = transform.right * speed * -1;
        }
    }
}