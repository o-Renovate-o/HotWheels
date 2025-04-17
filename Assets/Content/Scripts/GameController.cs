using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject[] cars;
    private Vector3[] carsStartPos;
    private Quaternion[] carsStartRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Car");
        
        carsStartPos = new Vector3[cars.Length];
        carsStartRot = new Quaternion[cars.Length];

        for (int i = 0; i < cars.Length; i++)
        {
            carsStartPos[i] = cars[i].transform.position;
            carsStartRot[i] = cars[i].transform.rotation;
            Debug.DrawRay(carsStartPos[i], Vector3.up * 5, Color.red, 10);
        }

        StartCoroutine(SubsribeToResetCoroutine());
    }

    private IEnumerator SubsribeToResetCoroutine()
    {
        yield return null;
        FindFirstObjectByType<InputController>().OnReset.AddListener(Respawn);
    }

    private void Respawn()
    {
        foreach (GameObject car in cars)
        {
            Rigidbody rb = car.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.transform.localRotation = Quaternion.identity;
            }
        }
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].transform.position = carsStartPos[i];
            cars[i].transform.rotation = carsStartRot[i];
        }
        StartCoroutine(stopPhysicsCoroutine());
    }

    private IEnumerator stopPhysicsCoroutine()
    {
        yield return null;
        foreach (GameObject car in cars)
        {
            Rigidbody rb = car.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }
}
