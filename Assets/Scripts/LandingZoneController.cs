using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (examManager != null)
            {
                if (examManager.CanLand())
                {
                    examManager.CompleteMission();
                }
                else
                {
                    Debug.Log("Cannot land yet! You must survive the Danger Zone first.");
                }
            }
        }
    }
}