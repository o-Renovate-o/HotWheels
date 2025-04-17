using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LaunchPowerBar : MonoBehaviour
{
    private float powerBarDirection = 1;
    public GameObject powerBar;
    public Image powerBarMask;
    public float barChangeSpeed = 1;
    float maxPowerBarValue = 100;
    float currentPowerBarValue;
    bool powerBarON;
    StartLauncher stLaunch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stLaunch = FindFirstObjectByType<StartLauncher>();
        RespwanPowerBar();
        StartCoroutine(UpdatePowerBar());
        FindFirstObjectByType<InputController>().OnReset.AddListener(RespwanPowerBar);
    }

    void RespwanPowerBar()
    {
        stLaunch.launchForce = 0;
        powerBar.SetActive(true);
        currentPowerBarValue = 0;
        powerBarDirection = 1;
        powerBarON = true;
        Debug.Log("Power Bar is respawned!");
    }

    IEnumerator UpdatePowerBar()
    {
        while (powerBarON || true)
        {
            if (!stLaunch.isLaunched)
            {
                currentPowerBarValue += barChangeSpeed * powerBarDirection;
                stLaunch.launchForce += 1500 * powerBarDirection;
                if (currentPowerBarValue <= 0 || currentPowerBarValue > maxPowerBarValue)
                    powerBarDirection *= -1;
            
                float fill = currentPowerBarValue / maxPowerBarValue;
                powerBarMask.fillAmount = fill;
            }
            yield return new WaitForSeconds(0.02f);

            if (stLaunch.isLaunched)
            {
                powerBarON = false;
                StartCoroutine(TurnOffPowerBar());
            }
        }
        yield return null;
    }

    IEnumerator TurnOffPowerBar()
    {
        yield return new WaitForSeconds(0.5f);
        if (!powerBarON)
        powerBar.SetActive(false);
    }

}
