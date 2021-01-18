using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Vector3 mousePosition;
    Vector2 direction;
    Rigidbody2D rb;
    public float moveSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
