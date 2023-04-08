using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float JumpForce;

    public float directionX;
    public SpriteRenderer sprite;
    public Animator animator;

    public BoxCollider2D boxCollider;
    public LayerMask jumpableGround;
    public VariableJoystick joystick;
    public enum AnimationStates { idle, running, jump, fall };
   void Update() {
        if (joystick.Vertical > 0.3 && IsGrounded()) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);
   }
        //directionX = Input.GetAxis("Horizontal");
        directionX = joystick.Horizontal;
        rigidbody.velocity = new Vector2(directionX * 10f, rigidbody.velocity.y);

        UpdateAnimation();

    }
    public void UpdateAnimation()
      {
       //  AnimationStates state;
          if (rigidbody.velocity.x > 0f)
          {
              //running right
              sprite.flipX = false;
              animator.SetInteger("state", 1);
          
          }
          else if (rigidbody.velocity.x < 0f)
          {
              //running left
              sprite.flipX = true;
              animator.SetInteger("state", 1);
          }
          else if (rigidbody.velocity.x == 0f)
          {
              //idle
              animator.SetInteger("state", 0);
          }
          if (rigidbody.velocity.y > 0.1f)
          {
            animator.SetInteger("state", 2);
          }
          else if (rigidbody.velocity.y < -0.1f)
          {
            animator.SetInteger("state", 3);

          }
        
      }
    public void ApplyDamage()
    {

    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f,Vector2.down,0.1f,jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            SoundManager.instance.audio.PlayOneShot(SoundManager.instance.collect);
        }
       
        if (other.gameObject.CompareTag("Finish"))
        {
            
            UImanager.instance.LevelFinish();
            
            UImanager.instance.FinishMenu.SetActive(true);
            
        }
    }

   
}
