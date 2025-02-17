﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    private Gamepad controller = null;
    private Transform m_transform;
    [SerializeField] float rotateSpeed;
    void Start()
    {
        this.controller = DS4.getConroller();
        m_transform = this.transform;
    }

    void Update()
    {
        if (controller == null)
        {
            try
            {
                controller = DS4.getConroller();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        else
        {
            // Press circle button to reset rotation
            if (controller.rightTrigger.isPressed)
            {
                //Debug.Log("reset rotation");
                m_transform.rotation = Quaternion.identity;
            }
            m_transform.rotation *= DS4.getRotation(rotateSpeed * Time.deltaTime);
        }
    }
}