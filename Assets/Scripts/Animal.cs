using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Animal : MonoBehaviour
{
    private Rigidbody2D myBody;
    private SpriteRenderer mySprite;
    
    [SerializeField] private float HorizontalSpeed = 1;

    private float minX, maxX;

    [SerializeField] [Range(-1,1)] private int movementDir = 1;
    
    [SerializeField] private int Health = 1;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x + mySprite.bounds.size.x/2;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x - mySprite.bounds.size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxX)
        {
            movementDir = -1;
        }else if (transform.position.x < minX)
        {
            movementDir = 1;
        }
    }

    // Preferable when using physics 
    private void FixedUpdate()
    {
        myBody.velocity = new Vector2(HorizontalSpeed * movementDir, myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (Health - 1 <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Health--;
            }
        }
        
    }
}
