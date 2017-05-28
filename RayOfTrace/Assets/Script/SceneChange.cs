using UnityEngine.SceneManagement;

public static class SceneChange
{
    public static void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

public struct SceneType
{
    public static string Title = "Title";
    public static string InGame = "InGame";
}