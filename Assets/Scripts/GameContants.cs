using UnityEngine;

public class GameContants : MonoBehaviour
{
    public const int LaneCount = 5;
    public const int LaneWidth = 1;

    public static float LaneToX(int laneIndex)
    {
        float center = (LaneCount - 1) / 2f;

        return (laneIndex - center) * LaneWidth;
    }

    public static int Centerlane => (LaneCount - 1) / 2;
}
