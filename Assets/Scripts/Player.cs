using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//MonoBehaviour: something to use on a scene 
public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 20f;

    private float minX, minY, maxX, maxY, startChargedTime, holdTime;

    private bool chargedShot, spacePressed;
    
    private SpriteRenderer mySprite;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletCharged;

    [SerializeField] private float fireDelay = 1;

    private float lastFireTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        Vector2 bottomLeftCorner = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRightCorner = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minX = bottomLeftCorner.x + mySprite.bounds.size.x/2;
        maxX = topRightCorner.x - mySprite.bounds.size.x/2;
        minY = bottomLeftCorner.y + mySprite.bounds.size.y/2;
        maxY = topRightCorner.y - mySprite.bounds.size.y/2;

        chargedShot = false;
        startChargedTime = 0;
        holdTime = 3f;
        
        //Debug.Log("Min x: "+ minX);
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        float yValue = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(xValue * speed * Time.deltaTime, yValue * speed * Time.deltaTime));

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)

        );

        if (Input.GetKeyDown(KeyCode.E))
        {
            chargedShot = !chargedShot;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
            if (chargedShot)
            {
                startChargedTime = Time.time;
            }
            else
            {
                Fire();
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            startChargedTime = 0;
            spacePressed = false;
        }

        if (Time.time - startChargedTime >= holdTime && spacePressed)
        {
            startChargedTime = Time.time;
            Fire();
         }
        
    }

    void Fire()
    {
        if (Time.time > fireDelay + lastFireTime)
        {
            if (chargedShot)
            {
                SoundManager.PlaySound("chargedShot");
                Instantiate(bulletCharged, transform.position, transform.rotation);
            }
            else
            {
                SoundManager.PlaySound("shortShot");
                Instantiate(bullet, transform.position, transform.rotation);
            }
            lastFireTime = Time.time;
            
        }
    }
}
