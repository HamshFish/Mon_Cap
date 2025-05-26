using UnityEngine;
[System.Serializable]
public class Game_Data
{
    public string data = "HELLO GRIMM!";
    public int troupeCode = 1034;
    public double troupePrecision = 10.34;
    public Float3 position = new Float3();
}
[System.Serializable]
public class Float3
{
    public float x, y, z;
    public void FromVector(Vector3 v)
    {
        x=v.x;
        y=v.y;
        z=v.z;
    }
    public Vector3 ToVector()
    { return new UnityEngine.Vector3(x, y, z); }
}
[System.Serializable]
public class HighScoreData
{
    public int[] scores;
    public string[] names;
    public HighScoreData()
    {
        scores = new[] { 99, 10, 34 };
        names = new[] { "Grimm", "Brumm", "Radiance" };
    }
    public HighScoreData(int[] scores, string[] names)
    {
        this.scores  = scores;
        this.names = names;
    }
}