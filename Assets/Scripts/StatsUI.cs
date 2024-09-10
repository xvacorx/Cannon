using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private TextMeshProUGUI forceText;
    [SerializeField] private TextMeshProUGUI xAngleText;
    [SerializeField] private TextMeshProUGUI yAngleText;
    [SerializeField] private TextMeshProUGUI impactForceText;

    [SerializeField] private LastShotInfo shotInfo;
    private float lastXAngle;
    private float lastYAngle;

    private CannonShooting projectileThrow;

    [System.Obsolete]
    private void Start()
    {
        projectileThrow = FindObjectOfType<CannonShooting>();

        shotInfo.ResetValues();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleUI();

        SetForceUI();
        SetAnglesUI();
    }

    private void ToggleUI()
    {
        if (statsPanel.activeSelf)
            statsPanel.SetActive(false);
        else
            statsPanel.SetActive(true);
    }

    private void SetForceUI()
    {
        forceText.text = $"Force: {string.Format("{0:0.##}", projectileThrow.powerSlider.value)}";
    }

    private void SetAnglesUI()
    {
        float xAngleToDisplay = projectileThrow.rotationXSlider.value;

        if (xAngleToDisplay > 180f)        
            xAngleToDisplay -= 360f;
        
        lastXAngle = xAngleToDisplay;
        xAngleText.text = $"xAngle: {string.Format("{0:0.##}", xAngleToDisplay)}°";

        float yAngleToDisplay = projectileThrow.rotationYSlider.value;

        if (yAngleToDisplay <= 360f && yAngleToDisplay > 305f)
            yAngleToDisplay = Mathf.Abs(yAngleToDisplay - 360f);
        else
            yAngleToDisplay = -yAngleToDisplay;

        lastYAngle = yAngleToDisplay;
        yAngleText.text = $"yAngle: {string.Format("{0:0.##}", yAngleToDisplay)}°";
    }

    public void SetImpactForceUI(float force)
    {
        impactForceText.text = $"Impact force: {string.Format("{0:0.##}", force)}";

        SetLastShotInfo(force);
    }

    private void SetLastShotInfo(float lastImpactForce)
    {
        shotInfo.Force = projectileThrow.powerSlider.value;
        shotInfo.X_Angle = lastXAngle;
        shotInfo.Y_Angle = lastYAngle;
        shotInfo.ImpactForce = lastImpactForce;
    }
}
