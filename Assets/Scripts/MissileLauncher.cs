// MissileLauncher.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Salih Çetin | Student ID: 230446013 

using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        if (missilePrefab != null && launchPoint != null)
        {
            activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
        }
        if (activeMissile != null)
        {
            MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
            if (homing != null)
            {
                homing.SetTarget(target);
            }
        }

        if (launchAudioSource != null)
        {
            launchAudioSource.Play();
        }

        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}