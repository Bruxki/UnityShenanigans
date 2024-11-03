using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [Header("Objects")]
    private GameObject lastObject; //last clicked object

    public GameObject object1;//other objects
    public GameObject object2;

    [Header("Camera")]
    public Camera cam;

    //Delegate and event for left-click detection
    delegate void ClickDown0();
    private event ClickDown0 onLeftClick;

    delegate void ClickDown1();
    private event ClickDown1 onRightClick;

    void Start()
    {
        onLeftClick += ObjectDetection;
        onRightClick += ObjectCreation;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //left-click
        {
            onLeftClick?.Invoke();
        }
        if (Input.GetMouseButtonDown(1))
        {
            onRightClick?.Invoke();
        }

        //To create other objects in the list we press q (for the first) or e (for the second)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lastObject = object1;
            Debug.Log("1st object");
        }
        if (Input.GetKeyDown(KeyCode.E))
        { 
            lastObject = object2;
            Debug.Log("2nd object");
        }

    }
    public void ObjectDetection()
    {
        

        if (cam == null)
        {
            Debug.Log("No camera");
            return;
        }

        //We detect an object using ray, also overriding whatever was in the the 0 object

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) )
        {
            GameObject clickedObject = hit.collider.gameObject;

            Debug.Log("object: " + clickedObject.name);

            lastObject = clickedObject;
        }
    }
    public void ObjectCreation()
    {
        if (lastObject == null)
        {
            Debug.Log("Choose an object first");
            return;
        }

        //ray from the camera
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //if we hit anything
        if (Physics.Raycast(ray, out hit) )
        {
            //position and rotation
            Vector3 spawnPosition = hit.point;
            Quaternion spawnRotation = Quaternion.LookRotation(hit.normal);
            //create the object
            Instantiate(lastObject, spawnPosition, spawnRotation);
        }
        //if nothing is hit
        else
        {
            Vector3 spawnPosition = cam.transform.position + cam.transform.forward * 2.0f;
            Quaternion spawnRotation = cam.transform.rotation;

            Instantiate(lastObject, spawnPosition, spawnRotation);
        }
    }
}
