using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationTPS : MonoBehaviour
{
    public Transform target;  // A követendő cél (játékos karakter)
    public float rotationSpeed = 5.0f;  // Forgatási sebesség
    public float verticalRotationSpeed = 2.0f;  // Vertikális forgatási sebesség
    public float zoomSpeed = 2.0f;  // Zoomolási sebesség
    public float minZoomDistance = 2.0f;  // Minimális zoom távolság
    public float maxZoomDistance = 10.0f;  // Maximális zoom távolság
    public float maxVerticalAngle = 80.0f;  // Maximális vertikális nézőszög

    private float currentZoomDistance = 5.0f;
    private float currentRotationX = 0.0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("A célpont nincs beállítva a kamera szkriptben!");
        }

        // Kurzor láthatóságának kikapcsolása
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Forgatás és mozgás az egér mozgásával
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalInput = Input.GetAxis("Mouse Y") * verticalRotationSpeed;

        // Kamera pozíciójának és nézési irányának beállítása
        currentRotationX -= verticalInput;
        currentRotationX = Mathf.Clamp(currentRotationX, -maxVerticalAngle, maxVerticalAngle);

        Quaternion rotation = Quaternion.Euler(currentRotationX, target.eulerAngles.y + horizontalInput, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * currentZoomDistance);

        transform.rotation = rotation;
        transform.position = position;

        // Zoomolás az egér görgetésével
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoomDistance -= scrollInput * zoomSpeed;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        

    }
}
