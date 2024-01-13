using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  
   public GameInput gameInput;

    //public GameObject yGimbal;
    //public Vector3 yGimbalRotation;

    //public Vector2 cameraRotation;
    public float sensitivityX;
   public float sensitivityY;
    public float minClamp;
    public float maxClamp;
    //public bool xInverted;
    //public bool yInverted;
    //public float currentRotationSmooth;

    //private void Update()
    //{
    //    FollowPlayer();
    //    CameraControl(); 

    //}


    //private void CameraControl()
    //{
    //    Vector2 cameraInput = gameInput.GetView();
    //   // cameraRotation.y += sensitivityX * cameraInput.x * Time.deltaTime;
    //   // transform.rotation = Quaternion.Euler(cameraRotation);


    //    player.move.y += (xInverted ? -(sensitivityX * cameraInput.x) : (sensitivityX * cameraInput.x)) * Time.deltaTime;
    //    transform.rotation = Quaternion.Euler(player.move);

    //    yGimbalRotation.x += (yInverted ? (sensitivityY * cameraInput.y) : -(sensitivityY * cameraInput.y)) * Time.deltaTime;
    //    yGimbalRotation.x = Mathf.Clamp(yGimbalRotation.x, minClamp, maxClamp);
    //    yGimbal.transform.localRotation = Quaternion.Euler(yGimbalRotation);


    //    // CameraHolder.localRotation = Quaternion.Euler(cameraRotation);
    //    if(player.targetCamera)
    //    {
    //        var currentRotation = player.transform.rotation;
    //        var newRotation = currentRotation.eulerAngles;

    //        newRotation.y = player.move.y;

    //        currentRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(newRotation), currentRotationSmooth);

    //        player.transform.rotation = currentRotation;
    //    }
    //}

    //private void FollowPlayer()
    //{
    //    transform.position = player.cameraTarget.position;
    //}
    public Transform CamereaHolder;
    public Vector3 cameraRotation;
    public Vector3 characterRotation;
    
    private void Awake()
    {
        cameraRotation = CamereaHolder.localRotation.eulerAngles;
        characterRotation = transform.localRotation.eulerAngles;
    }

    private void Update()
    {
       
        GetCameraRotation();
    }

    private void GetCameraRotation()
    {
        Vector3 inputCamera = gameInput.GetView();
        characterRotation.y += inputCamera.x * sensitivityX * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(characterRotation);

        cameraRotation.x += inputCamera.y * sensitivityY * Time.deltaTime;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, minClamp, maxClamp);
        CamereaHolder.localRotation = Quaternion.Euler(cameraRotation);
    }

}
