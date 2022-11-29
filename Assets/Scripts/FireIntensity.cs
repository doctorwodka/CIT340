using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class FireIntensity : MonoBehaviour
{
    public Light2D thisLight;


    float intensityDecreaseBy = 0.01f;
    float innerRadiusDecreaseBy = 0.005f;
    float outerRadiusDecreaseBy = 0.009f;

    // Start is called before the first frame update
    void Start()
    {

        thisLight = GetComponent<Light2D>();
        thisLight.intensity = 1;
        thisLight.pointLightInnerRadius = 2.5f;
        thisLight.pointLightOuterRadius = 5.5f;
    }


    // Update is called once per frame
    public void Update()
    {
        thisLight.intensity -= intensityDecreaseBy * Time.deltaTime;
        thisLight.pointLightInnerRadius -= innerRadiusDecreaseBy * Time.deltaTime;
        thisLight.pointLightOuterRadius -= outerRadiusDecreaseBy * Time.deltaTime;

        if (thisLight.intensity <= 0)
        {
            SceneManager.LoadScene("Died");
        }
    }

    public void IncreaseLight(float lightValue)
    {
        thisLight.intensity += lightValue;
        thisLight.pointLightInnerRadius += lightValue;
        thisLight.pointLightOuterRadius += lightValue;
    }

}
