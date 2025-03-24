using System;
using UnityEngine;
using UnityEngine.Device;

public class MenuQualityScript : MonoBehaviour
{
    [SerializeField]
    private Material[] daySkyboxes;
    private Material daySkyboxDefault;

    private TMPro.TMP_Dropdown graphicsDropdown;
    private TMPro.TMP_Dropdown fogDropdown;
    private TMPro.TMP_Dropdown dayDropdown;

    void Start()
    {
        Transform layout = this.transform.Find("Content/QualitySection/Layout");
        #region Graphics
        graphicsDropdown = layout
            .Find("Graphics/Dropdown")
            .GetComponent<TMPro.TMP_Dropdown>();
        //Debug.Log(string.Join(',', QualitySettings.names));
        graphicsDropdown.ClearOptions();
        foreach(string name in QualitySettings.names)
        {
            graphicsDropdown.options.Add(new(name));
        }

        int currentLevel = QualitySettings.GetQualityLevel();
        graphicsDropdown.value = currentLevel;
        #endregion

        #region Fog
        fogDropdown = layout
             .Find("Fog/Dropdown")
            .GetComponent<TMPro.TMP_Dropdown>();
        fogDropdown.ClearOptions();
        fogDropdown.options.Add(new("Off"));
        foreach (var value in Enum.GetValues(typeof(FogMode)))
        {
            fogDropdown.options.Add(new(value.ToString()));
        }
        fogDropdown.value = -1;
        fogDropdown.value = 0;
        #endregion

        #region Day
        dayDropdown = layout
            .Find("DaySky/Dropdown")
            .GetComponent<TMPro.TMP_Dropdown>();
        FillDaySkyboxDropdown();
        #endregion
        GameEventSystem.AddListener(OnGameEvent, nameof(GameState));
    }

    public void OnDaySkyDropdownChanged(int index)
    {
        if (index < daySkyboxes.Length)
        {
            //RenderSettings.skybox = daySkyboxes[index];
            GameState.daySkybox = daySkyboxes[index];
        }
        else
        {
            //RenderSettings.skybox = daySkyboxDefault;
            GameState.daySkybox = daySkyboxDefault;
        }
    }

    public void OnQualityDropdownChanged(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }

    public void OnFogDropdownChanged(int index)
    {
        if (index == 0)
        {
            RenderSettings.fog = false;
        }
        else
        {
            RenderSettings.fog = true;
            RenderSettings.fogMode = (FogMode)index;
        }
    }

    private void FillDaySkyboxDropdown()
    {
        daySkyboxDefault = RenderSettings.skybox;
        dayDropdown.ClearOptions();
        foreach (Material m in daySkyboxes)
        {
            dayDropdown.options.Add(new(m.name));
        }
        dayDropdown.options.Add(new("Default"));
        dayDropdown.value = daySkyboxes.Length;
    }

    private void OnGameEvent(string type, object payload)
    {
        if (nameof(GameState.activeSceneIndex).Equals(payload))
        {
            FillDaySkyboxDropdown();
        }
    }

    private void OnDestroy()
    {
        GameEventSystem.RemoveListener(OnGameEvent, nameof(GameState));
    }
}
