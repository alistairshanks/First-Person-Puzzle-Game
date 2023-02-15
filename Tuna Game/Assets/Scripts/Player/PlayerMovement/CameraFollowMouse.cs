using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    

    public float sensX;
    public float sensY;

    public Transform playerOrientation;

    float xRotation;
    float yRotation;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject sceneCamObj = GameObject.Find("SceneCamera");
        if (sceneCamObj != null)
        {
            // Should output the real dimensions of scene viewport
            Debug.Log(sceneCamObj.GetComponent<Camera>().pixelRect);
        }

    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate and cam orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //tells which direction we are facing on x axis for movement, so player can walk forward in direction they are facing
        playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }
}
