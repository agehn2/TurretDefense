using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*
       private bool doMovement = true;

       public float panSpeed = 30f;
       public float panBorderThickness = 10f;

       public float scrollSpeed = 5f;

       public float minY = 10f;
       public float maxY = 80f;
       public float minX = 5f;
       public float maxX = 70f;
       public float minZ = 0f;
       public float maxZ = 70f;

       // Update is called once per frame
       void Update() {

           if (Input.GetKeyDown(KeyCode.Escape))
               doMovement = !doMovement;

           if (!doMovement)
               return;

           if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
           {
               transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
           }

           if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
           {
               transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
           }

           if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
           {
               transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
           }

           if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
           {
               transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
           }

           float scroll = Input.GetAxis("Mouse ScrollWheel");

           Vector3 pos = transform.position;

           pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;
           pos.y = Mathf.Clamp(pos.y, minY, maxY);
           pos.x = Mathf.Clamp(pos.x, minX, maxX);
           pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

           transform.position = pos;

       }
   }
       */

    public float ScrollSpeed = 15f;

    //public float ScrollEdge = 0.1f;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float minY = -70f;
    public float maxY = 20f;
    public float minX = -10f;
    public float maxX = 10f;

    public float CurrentZoom = 0f;

    public float ZoomZpeed = 1f;

    public float ZoomRotation = 1f;

    public Vector2 zoomAngleRange = new Vector2(20, 70);

    public float rotateSpeed = 10f;

    private Vector3 initialPosition;

    private Vector3 initialRotation;


    void Start()
    {
        //initialPosition = transform.position;
        //initialRotation = transform.eulerAngles;
    }


    void Update()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        // panning     
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * panSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);
        }

        else
        {
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
        }



        // zoom in/out
        CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;

        CurrentZoom = Mathf.Clamp(CurrentZoom, minY, maxY);

        transform.position = new Vector3(transform.position.x, transform.position.y - (transform.position.y - (initialPosition.y + CurrentZoom)) * 0.1f, transform.position.z);

        float x = transform.eulerAngles.x - (transform.eulerAngles.x - (initialRotation.x + CurrentZoom * ZoomRotation)) * 0.1f;
        x = Mathf.Clamp(x, zoomAngleRange.x, zoomAngleRange.y);

        transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}