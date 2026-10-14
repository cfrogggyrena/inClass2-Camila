using System;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

using UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(CharacterController))] //requires it to work
public class MainPlayerControllerAndroid : MonoBehaviour
{
    private Vector2 touchStartPosition, touchEndPosition;
    private string directions;


    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }


    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            Touch touch = Touch.activeTouches[0];
            if (touch.began)
            {
                touchStartPosition = touch.screenPosition;
            }
            else if (touch.ended)
            {
                touchEndPosition = touch.screenPosition;
                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    direction = "Tapped";

                }
                else if (Math.Abs(x) > Mathf.Abs(y))
                {
                    direction = x > 0 ? "Right" : "Left";
                }
                else
                {
                    direction = y > 0 ? "Up" : "Down";
                }
                Debug.Log($"Mobile input {direction}");
            }

            Debug.Log($"Mobile input {touch.screenPosition}");

        }

    }
}
