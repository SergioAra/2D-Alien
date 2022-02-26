using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedBullet : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        SoundManager.PlaySound("chargedImpact");
        anim.Play("blueBulletAnimation");
        Destroy(gameObject, 0.1f);
    }
}
