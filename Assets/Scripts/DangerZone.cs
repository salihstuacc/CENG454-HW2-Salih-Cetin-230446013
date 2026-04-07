using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (examManager != null)
            {
                examManager.EnterDangerZone();
            }
            activeCountdown = StartCoroutine(MissileCountdown(collision.transform));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
                Debug.Log("Countdown cancelled. Player escaped!");
            }
            if (examManager != null)
            {
                examManager.ExitDangerZone();
            }
            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
        }
    }

    private IEnumerator MissileCountdown(Transform playerTarget)
    {
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("5 seconds passed! ((Missile will launch here)");

        if (missileLauncher != null)
        {
            missileLauncher.Launch(playerTarget);
        }
        activeCountdown = null;
    }
}