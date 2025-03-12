
public class GameState
{
    public static float gameTime24              { get; set; } = 12.0f;

    public static float coinSpawnRadius         { get; set; } = 30.0f;
    public static float coinSpawnProbability    { get; set; } = 0.5f;
    public static float radarRadius             { get; set; } = 30.0f;
    public static float staminaLimit            { get; set; } = 10.0f;

    public static bool isCompassVisible         { get; set; } = true;
    public static bool isRadarVisible           { get; set; } = true;
    public static bool isHintsVisible           { get; set; } = true;
    public static bool isClockVisible           { get; set; } = true;
}
