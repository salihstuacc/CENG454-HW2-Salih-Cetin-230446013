using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    public void EnterDangerZone()
    {
        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
        }

        if (missionText != null)
        {
            missionText.text = "Mission: SURVIVE AND ESCAPE!";
        }
    }

    public void ExitDangerZone()
    {
        threatCleared = true;

        if (statusText != null)
        {
            statusText.text = "Threat Cleared. You are safe to Land.";
            statusText.color = Color.green;
        }
        if (missionText != null)
        {
            missionText.text = "Mission: Land safely on the landing strip.";
        }
    }
}