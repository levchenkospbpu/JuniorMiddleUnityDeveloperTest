using System.Collections.Generic;

public static class ResultList
{
    public static List<float> Results { get; private set; } = new ();
    public static float LastTime { get; private set; }

    public static void SetLastTime(float time)
    {
        LastTime = time;
    }
}
