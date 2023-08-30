using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError(other.gameObject.name);

        if (!other.CompareTag("Player")) return;
        GameManager.Instance.OnDoorEnter();

    }
}
