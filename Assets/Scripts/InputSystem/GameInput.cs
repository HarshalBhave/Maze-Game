using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameInput : MonoBehaviour
{
    // Game Input System 
    
    public PlayerInput inputActions;
   

    
    private void Awake()
    {
        inputActions = new PlayerInput();
        
        inputActions.Movement.Enable();
        
    }

    public Vector2 GetView()
    {
        Vector2 cameraInput = inputActions.Movement.View.ReadValue<Vector2>();
        return cameraInput;
    }

    public Vector2 GetInput() 
    {
        Vector2 playerInput = inputActions.Movement.Move.ReadValue<Vector2>();

      //  playerInput = playerInput.normalized;
        return playerInput;
    }


}
