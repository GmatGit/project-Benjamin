using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_mozgas : MonoBehaviour
{
    private float x;
    private float y;
    public float sensitivity = -1f;
    private Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");
        rotate = new Vector3(y, x * sensitivity, 0);
        transform.eulerAngles -= rotate;
    }
}
