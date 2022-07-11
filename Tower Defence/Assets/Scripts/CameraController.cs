using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PanSpeed = 30f;
    public float ScrollSpeed = 5f;

    private float minY = 10f;
    private float maxY = 80f;
    private float minX = -5f;
    private float maxX = 60f;
    private float minZ = -70f;
    private float maxZ = 0f;

    private float PanBorderThickness = Screen.height / 20;
    private bool doMovement = true;
    void Update()
    {
        if (GameManager.GameOver)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PanBorderThickness = -1f;
        }
        PanBorderThickness = Screen.height / 20;
        // Camera Movement
        if (Input.GetKey("w") || Input.mousePosition.y >= (Screen.height - PanBorderThickness))
        {
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= (PanBorderThickness))
        {
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= (PanBorderThickness))
        {
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= (Screen.width - PanBorderThickness))
        {
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            pos.y -= scroll * 1000 * ScrollSpeed * Time.deltaTime;
        }
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;

    }
}
