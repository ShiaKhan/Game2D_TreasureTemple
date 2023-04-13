using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    [SerializeField] float jumpSpeed = 6f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float delaytime = 5f;

   

    
    Vector2 moveInput;
    Rigidbody2D MyRigidbody;
    Animator MyAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float GravityScaleAtStart;
    bool isAlive = true;
    

    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        GravityScaleAtStart = MyRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive){return;}
        Run();
        FlipSprite(); //lat nhan vat
        ClimbLadder();
        Die();
    }

    //Tao vien dan cho player
    void OnFire(InputValue value)
    {
        if(!isAlive){return;}
        Instantiate(bullet, gun.position, transform.rotation);
    }

    //Di chuyen nhan vat
    void OnMove(InputValue value)
    {
        if(!isAlive){return;}
        moveInput = value.Get<Vector2>();
    }

    //Nhay Jump - setting gioi han jump
    void OnJump(InputValue value)
    {
        if(!isAlive){return;}
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}
        if(value.isPressed)
        {
            MyRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }
    //Di chuyen nhan vat quay sang hai huong left and right.
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * Speed, MyRigidbody.velocity.y);
        MyRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(MyRigidbody.velocity.x) > Mathf.Epsilon;
        MyAnimator.SetBool("isRuning", playerHasHorizontalSpeed);
    }

    //lat huong nhan vat
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(MyRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(MyRigidbody.velocity.x), 1f);
        }    
    }

    //Leo thang
    void ClimbLadder()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            MyRigidbody.gravityScale = GravityScaleAtStart; //thay doi trong luc khi player cham vao thang
            MyAnimator.SetBool("isClimbing", false);
            return;
        }
        Vector2 ClimbVelocity = new Vector2(MyRigidbody.velocity.x, moveInput.y * climbSpeed);
        MyRigidbody.velocity = ClimbVelocity;
        MyRigidbody.gravityScale = 0f;  // thiet lap lai trong luc bang 0;

        bool playerHasVerticalSpeed = Mathf.Abs(MyRigidbody.velocity.y) > Mathf.Epsilon;
        MyAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
    }

    //Die khi cham vao Enemy
    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards","Water"))) //ten bien nam trong bang layer
        {
            isAlive = false;
            MyAnimator.SetTrigger("Dying");
            MyRigidbody.velocity = deathKick; 
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            StartCoroutine(WaitForSeconds("Dying", delaytime));
        }
        
    }

    IEnumerator WaitForSeconds(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
