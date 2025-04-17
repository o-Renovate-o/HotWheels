using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [field:SerializeField]
    public UnityEvent OnReset { get; private set; }

    [field: SerializeField]
    public UnityEvent OnLaunch { get; private set; }

    public float LauncherRotationDirection { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReset?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnLaunch?.Invoke();
        }

        LauncherRotationDirection = Input.GetAxis("Horizontal");

    }
}
