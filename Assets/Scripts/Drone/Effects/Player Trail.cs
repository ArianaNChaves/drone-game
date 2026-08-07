using System;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    [SerializeField] private GameObject playerTrail;
    [SerializeField] private InputReaderDrone inputReader;
    
    private void Start()
    {
        inputReader.IsSprintingEvent += ShowTrail;
    }

    private void ShowTrail(bool obj)
    {
        if (obj)
        {
            playerTrail.SetActive(true);
        }
        else
        {

            playerTrail.SetActive(false);

        }
    }
}
