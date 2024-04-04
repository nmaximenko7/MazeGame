using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public enum RotationAxes
    {
        XandY,
        Y,
        X
    }
    public RotationAxes axes = RotationAxes.XandY;

    private Touch _rotateTouch;
    private Vector2 _startTouchPos;
    private float _minVert = -45.0f;
    private float _maxVert = 45.0f;
    private float _rotationY = 0;

    public float rotationSpeed = 0.1f;

    void Update()
    {
        if (Input.touchCount > 0 && Input.touchCount < 3)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                _rotateTouch = Input.GetTouch(i);
                if (_rotateTouch.position.x < Screen.width / 2f) continue;
                if (_rotateTouch.phase == TouchPhase.Began)
                {
                    _startTouchPos = _rotateTouch.position;
                }
                else if (_rotateTouch.phase == TouchPhase.Moved)
                {
                    if (axes == RotationAxes.XandY)
                    {

                    }
                    else if (axes == RotationAxes.X)
                        transform.Rotate(Vector3.up, (_rotateTouch.position.x - _startTouchPos.x) * rotationSpeed, Space.World);
                    else if (axes == RotationAxes.Y)
                    {
                        float rotationX = transform.localEulerAngles.y;
                        _rotationY -= (_rotateTouch.position.y - _startTouchPos.y) * rotationSpeed;
                        _rotationY = Mathf.Clamp(_rotationY, _minVert, _maxVert);
                        transform.localEulerAngles = new Vector3(_rotationY, rotationX, 0);
                    }
                    _startTouchPos = _rotateTouch.position;
                }
            }
        } 
    }
}
