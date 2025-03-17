using UnityEngine;
using UnityEngine.UI;

public class MenuDifficultyScript : MonoBehaviour
{
    private Toggle compassToggle;
    private Toggle clockToggle;
    private Toggle hintsToggle;
    private Toggle radarToggle;

    void Start()
    {
        Transform togglesLayout = transform.Find("Content/DifficultySection/TogglesLayout");
        compassToggle = togglesLayout.Find("Compass/CompassToggle").GetComponent<Toggle>();
        compassToggle.isOn = GameState.isCompassVisible;

        clockToggle = togglesLayout.Find("Clock/ClockToggle").GetComponent<Toggle>();
        clockToggle.isOn = GameState.isClockVisible;

        hintsToggle = togglesLayout.Find("Hints/HintsToggle").GetComponent<Toggle>();
        radarToggle = togglesLayout.Find("Radar/RadarToggle").GetComponent<Toggle>();
    }

    void Update()
    {
        
    }

    public void OnClockToggleChanged(bool value)
    {
        GameState.isClockVisible = value;
    }
    public void OnCompassToggleChanged(bool value)
    {
        GameState.isCompassVisible = value;
    }
}
