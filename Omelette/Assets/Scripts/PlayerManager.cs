using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float maxSanityLevel;
    private PostProcessingProfile ppProfile;
    public float sanityLevel;

    private void Start()
    {
        ppProfile = cam.GetComponent<PostProcessingBehaviour>().profile;
        sanityLevel = maxSanityLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sanityLevel++;
            ChangePostProcessing();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            sanityLevel--;
            ChangePostProcessing();
        }

    }

    private void ChangePostProcessing()
    {
        VignetteModel.Settings vign = ppProfile.vignette.settings;
        vign.intensity = (sanityLevel / maxSanityLevel);
        ppProfile.vignette.settings = vign;

        ColorGradingModel.Settings CGrad = ppProfile.colorGrading.settings;
        CGrad.basic.saturation = (sanityLevel / maxSanityLevel);
        ppProfile.colorGrading.settings = CGrad;
    }
}