using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int FPS = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
