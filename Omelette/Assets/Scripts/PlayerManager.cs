using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float maxSanityLevel;
    [SerializeField]
    private float sanityLossPerMinute;
    private PostProcessingProfile ppProfile;
    [SerializeField]
    private float vignIntensity;
    [SerializeField]
    private bool canLose;
    [SerializeField]
    AudioSource[] sanityMusicSources = new AudioSource[3];
    [SerializeField]
    AudioClip[] music = new AudioClip[3];
    public float sanityLevel;
    public bool hasWin;

    private void Start()
    {
        ppProfile = cam.GetComponent<PostProcessingBehaviour>().profile;
        sanityLevel = maxSanityLevel;
        ResetPostProcessing();
        StartCoroutine(LoseSanityOverTime());
        for (int i = 0; i < sanityMusicSources.Length; i++)
        {
            sanityMusicSources[i].clip = music[i];
        }
        sanityMusicSources[0].Play();
    }

    public void DecreaseSanity(float changeAmount)
    {
        if (sanityLevel - changeAmount < 0)
        {
            sanityLevel = 0;
            ChangePostProcessing();
            if(canLose) Lose();
        }
        else
        {
            sanityLevel -= changeAmount;
            if(sanityLevel != maxSanityLevel)
            {
                sanityMusicSources[1].Play();
            }
            if(sanityLevel < maxSanityLevel * 0.5f)
            {
                sanityMusicSources[2].Play();
            }
            ChangePostProcessing();
        }
    }

    private IEnumerator LoseSanityOverTime()
    {
        while (true)
        {
            DecreaseSanity(sanityLossPerMinute / 120f);
            yield return new WaitForSeconds(.5f);
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ChangePostProcessing()
    {
        VignetteModel.Settings vign = ppProfile.vignette.settings;
        vign.intensity = Mathf.Clamp(1 - (sanityLevel / maxSanityLevel) * vignIntensity, 0, 1);
        ppProfile.vignette.settings = vign;

        ColorGradingModel.Settings CGrad = ppProfile.colorGrading.settings;
        CGrad.basic.saturation = (sanityLevel / maxSanityLevel);
        ppProfile.colorGrading.settings = CGrad;
    }

	public float GetCurrentSanityOnScale01()
	{
		return Mathf.Clamp01(Mathf.InverseLerp(maxSanityLevel, 0, sanityLevel));
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