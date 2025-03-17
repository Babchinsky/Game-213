
public class GameState
{
    public static float gameTime24              { get; set; } = 12.0f;

    public static float coinSpawnRadius         { get; set; } = 30.0f;
    public static float coinSpawnProbability    { get; set; } = 0.5f;
    public static float radarRadius             { get; set; } = 30.0f;
    public static float staminaLimit            { get; set; } = 10.0f;


    #region isCompassVisible
    public static bool _isCompassVisible = true;
    public static bool isCompassVisible
    {
        get => _isCompassVisible;
        set
        {
            if (value != _isCompassVisible)
            {
                _isCompassVisible = value;
                GameEventSystem.EmitEvent(nameof(GameState), nameof(isCompassVisible));
            }
        }
    }
    #endregion

    public static bool isRadarVisible           { get; set; } = true;
    public static bool isHintsVisible           { get; set; } = true;
    
    #region isClockVisible
    private static bool _isClockVisible = true;
    public static bool isClockVisible
    {
        get => _isClockVisible;
        set
        {
            if (value != _isClockVisible)
            {
                _isClockVisible = value;
                GameEventSystem.EmitEvent(nameof(GameState), nameof(isClockVisible));
            }
        }
    }
    #endregion
}
