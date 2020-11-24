using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public float mouseSensitivity = 10;
   public Transform target;
   public float dstFromTarget = 2;
   public Vector2 pitchMinMax = new Vector2(-40,90);
   public float rotationSmoothTime = .12f;
   private Vector3 rotationSmoothVelocity;
   private Vector3 currentRotation;
   private float yaw;
   private float pitch;

   void Start()
   {
     
   }

   private void LateUpdate()
   {
      yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
      pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
      pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
      currentRotation = Vector3.SmoothDamp(currentRotation,new Vector3(pitch,yaw), ref rotationSmoothVelocity,rotationSmoothTime);
      transform.eulerAngles = currentRotation;
      transform.position = target.position - transform.forward * dstFromTarget;
   }
}
