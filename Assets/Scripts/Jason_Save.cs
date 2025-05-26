using UnityEngine;
using System.IO;
public static class Jason_Save
{
    public static string file = Application.dataPath + "/save.json";
    public static void Save(HighScoreData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(file, json);
    }
    public static HighScoreData Load()
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            return JsonUtility.FromJson<HighScoreData>(json);
        }
        return null;
    }

}
