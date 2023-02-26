using System;

[Serializable]
public class Score
{
    public int Enemies;
    public int Survivors;
    public float Time;
    public float ScorePoints;

    public Score(float time, int enemies, int survivors)
    {
        Time = time;
        Enemies = enemies;
        Survivors = survivors;
        ScorePoints = time + enemies + (survivors * 5);
    }
}
