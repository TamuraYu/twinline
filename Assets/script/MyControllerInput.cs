using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class MyControllerInput : MonoBehaviour
{
    public Material[] _material;
    private GameObject _plane;
    private GameObject _arrow;
    private MLInputController _controller;
    private const float _rotationSpeed = 1.0f;
    private const float _distance = 2.0f;
    private const float _moveSpeed = 1.2f;
    private bool _enabled = false;
    private bool _bumper = false;
    private bool _trigger = false;
    private bool ray_trigger = false;
    void Start()
    {
        _enabled = true;
        _plane = GameObject.Find("Root");
//        _arrow = GameObject.Find("Arrow");
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    void OnDestroy()
    {
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }

    void Update()
    {
        if (_controller.TriggerValue > 0.2f)
        {
            _plane.transform.position = new Vector3(_plane.transform.position.x, this.transform.position.y - 0.1f, _plane.transform.position.z);
//            _arrow.transform.position = new Vector3(_arrow.transform.position.x, this.transform.position.y, _arrow.transform.position.z);


        }

        CheckControl();
    }

    void CheckControl()
    {

        if (_controller.Touch1PosAndForce.z > 0.0f && _enabled)
        {
            float X = _controller.Touch1PosAndForce.x;
            float Y = _controller.Touch1PosAndForce.y;
            Vector3 forward = Vector3.Normalize(Vector3.ProjectOnPlane(transform.forward, Vector3.up));
            Vector3 right = Vector3.Normalize(Vector3.ProjectOnPlane(transform.right, Vector3.up));
            Vector3 force = Vector3.Normalize((X * right) + (Y * forward));
        }
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper)
        {
            _bumper = true;
//            _arrow.transform.position = new Vector3(this.transform.position.x, _arrow.transform.position.y, this.transform.position.z);
//            _arrow.transform.rotation = Quaternion.Euler(new Vector3(_arrow.transform.rotation.x, this.transform.rotation.y, _arrow.transform.rotation.z));
        }
    }

    void OnButtonUp(byte controller_id, MLInputControllerButton button)
    {

        if (button == MLInputControllerButton.Bumper)
        {
            _bumper = false;
        }
    }

}