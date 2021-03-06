﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler Instance;

    public GameObject pistolObject;
    public ParticleSystem muzzleFlash;

    public bool muzzleActive = false;
    float muzzleTimer = 0.1f;

    public Animator playerAnimator;
    public Texture2D crossHair;

    public bool pistolActive = false;

    private void Awake()
    {

        if (Instance != this || Instance == null)
            Instance = this;
    }

    private void Update()
    {
        //Equip pistol
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerCharacterController.Instance.Alive)
        {
            pistolActive = !pistolActive;
            SoundManager.instance.PlaySound(1);
        }

        PistolActive();
        SetCursor();



        if (muzzleActive)
        {
            muzzleFlash.gameObject.SetActive(true);
            muzzleTimer -= Time.deltaTime;

            if (muzzleTimer <= 0)
            {
                muzzleActive = false;
                muzzleFlash.gameObject.SetActive(false);
                muzzleTimer = 0.1f;
            }
        }
    }

    void PistolActive()
    {
        if (pistolActive)
        {
            playerAnimator.SetBool("pistolActive", true);
            pistolObject.SetActive(true);
        }
        else
        {
            playerAnimator.SetBool("pistolActive", false);
            pistolObject.SetActive(false);
        }
    }

    void SetCursor()
    {
        // Set crosshair cursor while aiming
        if (PlayerCharacterController.IsAiming && pistolActive)
        {
            Cursor.SetCursor(crossHair, new Vector2(25f, 25f), CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
