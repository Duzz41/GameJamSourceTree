using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class CameraMovement : MonoBehaviour
{
    private NewControls cameraActions;
    private InputAction movement;
    private Transform cameraTransform;

    [Header("Horizontal Translation")]
    
    [SerializeField]
    private float maxSpeed=5f;
    private float speed;
    private float acceleration=10f;
    private float damping=15f;

    [Header("Vertical Translation")]
    [SerializeField]
    private float stepSize=2f;
    private float zoomDampening=7.5f;
    private float maxHeight=10f;
    private float minHeight=10f;
    private float zoomSpeed=2f;
    
   

    
    








    public void OnMove()
    {

    }
}
