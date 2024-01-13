using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :  MonoBehaviour
{

    // Player Movement 
    public GameInput gameInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public Vector3 move;
  

    public bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -12.81f;

    private float currentSpeed = 2f;

    // To control the animation
    public bool isWalking;
    public bool isRunning;
    public bool isJumping;

    // KnockBack Effect using Rigidbody
  //  private Rigidbody rb;

  //  public Transform center;
    //public float knockbackVelocity;
    //public float knockbackTimer = 5f;
   public bool knockbackBool;


    // Inventory System
    public InventorySystem inventorySystem;


    // Camera controls
    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;
    [SerializeField] private float minClamp;
    [SerializeField] private float maxClamp;

    public Transform CamereaHolder;
    private Vector3 cameraRotation;
    private Vector3 characterRotation;

    [SerializeField] private bool xInverted;
    [SerializeField] private bool yInverted;
   



    private void Awake()
    {
        cameraRotation = CamereaHolder.localRotation.eulerAngles;
        characterRotation = transform.localRotation.eulerAngles;
        controller = GetComponent<CharacterController>();
      //  rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement(); //GetRotation();
        GetCameraRotation();

    }
        private void GetCameraRotation()
        {
            Vector3 inputCamera = gameInput.GetView();
            characterRotation.y += sensitivityX * (xInverted ? -inputCamera.x : inputCamera.x) * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(characterRotation);

            cameraRotation.x +=  sensitivityY * (yInverted ? inputCamera.y  : -inputCamera.y) * Time.deltaTime;
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, minClamp, maxClamp);
            CamereaHolder.localRotation = Quaternion.Euler(cameraRotation);
        }

        private void Movement()
    {
        Vector2 characterInput = gameInput.GetInput();

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            isJumping = false;
        }

        move = new Vector3(characterInput.x, 0, characterInput.y);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = playerSpeed;
            isRunning = true;
        }
        else
        {
            playerSpeed = currentSpeed;
            isRunning = false;
        }

        isWalking = move != Vector3.zero;
        move = transform.TransformDirection(move);
        controller.Move(move * (isRunning ? currentSpeed * playerSpeed : playerSpeed) *  Time.deltaTime);

        if (move != Vector3.zero)
        {
            //transform.forward = move;
            // transform.Rotate(Vector3.up * move.x * targetRotationSpeed * Time.deltaTime);
            //  Quaternion targetRotatio = Quaternion.LookRotation(postionToLookAt);
          
         //   transform.rotation = Quaternion.Slerp(a: transform.rotation, b: Quaternion.LookRotation(move), t: targetRotationSpeed * Time.deltaTime);
        }


        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            isJumping = true;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }





    public bool IsWalking()
    {
        return isWalking;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    


    //public void Knockback(Transform transform)
    //{
    //    var dir = center.position - transform.position;
    //    rb.velocity = (dir.normalized * knockbackVelocity); 
    //    Debug.Log(dir);
    //    controller.enabled = false;
    //    StartCoroutine(UnknockBack());
    //}

    //private IEnumerator UnknockBack()
    //{
    //    yield return new WaitForSeconds(knockbackTimer);
    //    controller.enabled = true;
    //    knockbackBool = false;
    //}


    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<InventoryItems>();
        if(item)
        {
            inventorySystem.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }


    private void OnApplicationQuit()
    {
        inventorySystem.inventoryslots.Clear();
    }

   

}
 