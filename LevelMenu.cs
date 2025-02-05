using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelid)
    {
        string levelName = "Level" + levelid;
        SceneManager.LoadScene(levelName);
    }
}
