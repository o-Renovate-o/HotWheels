using UnityEngine;
using System.Collections;
using System;
public class StartLauncher : MonoBehaviour
{
    [HideInInspector] public float launchForce = 0;
    public Rigidbody rb;
    [HideInInspector] public bool isLaunched;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLaunched = false;
        FindFirstObjectByType<InputController>().OnReset.AddListener(ResetLauncher);
        FindFirstObjectByType<InputController>().OnLaunch.AddListener(LaunchPlayer);
    }

    private void ResetLauncher()
    {
        isLaunched = false;
    }

    private void LaunchPlayer()
    {
        rb.AddForce(transform.forward * launchForce);
        isLaunched = true;
        Debug.Log("Car Launch!");
    }
}
