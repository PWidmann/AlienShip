﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameManager.SelfDestrucionActive)
        {
            Time.timeScale = 0;
            GameInterface.Instance.winScreen.SetActive(true);
        }
    }
}
