using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] Player player;

    private const string IS_WALK = "HorizontalMovement";
    private const string IS_WALKING = "Walking";
    private const string IS_JUMP = "Jump";
    private const string IS_StumbleBack = "StumbleBackwards";
    //private const string BOX_HOLDER = "BoxHolder";
    //private float velocity;
    int VelocityHash;
    public float acceleration = 0.1f;
    public float running;
    public float walk;
    private void Awake()
    {
        animator = GetComponent<Animator>();
     //   VelocityHash = Animator.StringToHash("Velocity");
    } 

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
      //  animator.SetFloat(IS_WALK, player.moveDire.z);
        animator.SetFloat("Run", running);
        animator.SetFloat("Walk", walk);
      //  animator.SetBool(IS_RUNNING, player.IsRunning());
        animator.SetBool(IS_JUMP, player.isJumping);
        animator.SetBool(IS_StumbleBack, player.knockbackBool);
        //// animator.SetBool(BOX_HOLDER, player.isHolding);
        ///
        if (!player.IsRunning())
        {
            running = 0.1f;
            walk = 1f;
        } else
        {
            running = 1;
            walk = 0.3f;
        }
    //    animator.SetFloat(VelocityHash, velocity);
            
    }

}
