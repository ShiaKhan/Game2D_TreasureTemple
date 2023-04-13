using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D MyRigidbody;
    PlayerMovement player;
    float xSpeed;
  
    
    
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        FindObjectOfType<AudioPlayer>().PlayShootingClip();

    }

    void Update()
    {
        MyRigidbody.velocity = new Vector2 (xSpeed, 0f);
        transform.Rotate(0,0,-90);
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            

        }
        FindObjectOfType<AudioPlayer>().PlayDamageClip();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
