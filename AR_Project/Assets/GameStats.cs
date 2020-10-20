using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats
{

    public static float volumeMusic = .5f;
    public static float volumeFx = .5f;
    public static string score = "0";
    public static string arrows = "10";
    public static double nbArrows = 10;
    public static double nbArrowsMax = 10;

    public static void setVolumeMusic(float vol)
    {
        volumeMusic = vol;
    }
    public static void setVolumeFx(float vol)
    {
        volumeFx = vol;
    }
    public static void setScore(double newScore)
    {
        score = newScore.ToString();
    }
    public static void setArrows(double newArrows)
    {
        arrows = newArrows.ToString();
        nbArrows = newArrows;
    }
}
