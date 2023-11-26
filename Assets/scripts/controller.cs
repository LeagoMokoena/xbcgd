using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class controller : MonoBehaviour
{
    //public Camera Camera;
    public float ewalk = 6f;
    public float riun = 12f;
    public float jumo = 7f;
    public float gravit = 10f;

    public float look = 2f;
    public float lokkx = 45f;

    Vector3 movedir = Vector3.zero;
    float rotatex = 0;

    public bool movecan = true;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forw = transform.TransformDirection(Vector3.forward);
        Vector3 rig = transform.TransformDirection(Vector3.right);

        bool isrun = Input.GetKey(KeyCode.LeftShift);
        float curspX = movecan ? (isrun ? riun : ewalk) * Input.GetAxis("Vertical") : 0;
        float curspY = movecan ? (isrun ? riun : ewalk) * Input.GetAxis("Horizontal") : 0;
        float movementY = movedir.y;
        movedir = (forw * curspX) + (rig * curspY);

        if(Input.GetButton("Jump")&& movecan && characterController.isGrounded)
        {
            movedir.y = jumo;
        }
        else
        {
            movedir.y = movementY;
        }

        if(!characterController.isGrounded)
        {
            movedir.y -= gravit * Time.deltaTime;
        }

       
        characterController.Move(movedir * Time.deltaTime);
        /*if (movecan)
        {
            rotatex += -Input.GetAxis("Mouse Y") * look;
            rotatex = Mathf.Clamp(rotatex, -lokkx, lokkx);
            //Camera.transform.localRotation = Quaternion.Euler(rotatex, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * look, 0);
        }*/

    }
}
