using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform Orien;

    public float xS;
    float xR;
    public float yS;
    float yR;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mX = Input.GetAxisRaw("Mouse X") * xS * Time.deltaTime;
            float mY = Input.GetAxisRaw("Mouse Y") * yS * Time.deltaTime;

            xR -= mY;
            xR = Mathf.Clamp(xR, -45.0f, 45.0f);
            yR += mX;

            //rotate camera
            transform.rotation = Quaternion.Euler(xR, yR, 0);
            //rotate Player
            Orien.rotation = Quaternion.Euler(xR, yR, 0);
        }
    }
}
