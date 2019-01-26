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
    [SerializeField]
    private float vignIntensity;
    public float sanityLevel;

    private void Start()
    {
        ppProfile = cam.GetComponent<PostProcessingBehaviour>().profile;
        sanityLevel = maxSanityLevel;
        ResetPostProcessing();
    }

    public void DecreaseSanity(float changeAmount)
    {
        Debug.Log("@DecreaseSanity" + changeAmount);
        if (sanityLevel - changeAmount < 0)
        {
            sanityLevel = 0;
            ChangePostProcessing();
        }
        else
        {
            sanityLevel -= changeAmount;
            ChangePostProcessing();
        }
    }

    private void ChangePostProcessing()
    {
        VignetteModel.Settings vign = ppProfile.vignette.settings;
        vign.intensity = Mathf.Clamp(1 - (sanityLevel / maxSanityLevel) * vignIntensity, 0, 1);
        Debug.Log(vign.intensity);
        ppProfile.vignette.settings = vign;

        ColorGradingModel.Settings CGrad = ppProfile.colorGrading.settings;
        CGrad.basic.saturation = (sanityLevel / maxSanityLevel);
        ppProfile.colorGrading.settings = CGrad;
    }

	private void OnDisable()
	{
		ResetPostProcessing();
	}

	private void ResetPostProcessing()
    {
        VignetteModel.Settings vign = ppProfile.vignette.settings;
        vign.intensity = 0;
        ppProfile.vignette.settings = vign;

        ColorGradingModel.Settings CGrad = ppProfile.colorGrading.settings;
        CGrad.basic.saturation = 1;
        ppProfile.colorGrading.settings = CGrad;
    }
}