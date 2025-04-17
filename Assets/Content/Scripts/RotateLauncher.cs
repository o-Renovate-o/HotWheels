using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class RotateLauncher : MonoBehaviour
{
    public float rotSpeed = 1;
    StartLauncher stLaunch;
    public Rigidbody rb;
    private InputController inputController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputController = FindFirstObjectByType<InputController>();
        inputController.OnReset.AddListener(ResetLauncher);
        stLaunch = FindFirstObjectByType<StartLauncher>();

    }

    private void Update()
    {
        OnRotateLauncher(inputController.LauncherRotationDirection);
    }

    // Update is called once per frame
    void OnRotateLauncher(float direction)
    {
        if (!stLaunch.isLaunched)
        {
            transform.Rotate(0, direction * rotSpeed * Time.deltaTime, 0);
        }
    }

    void ResetLauncher()
    {
        transform.localRotation = Quaternion.identity;
    }
}
