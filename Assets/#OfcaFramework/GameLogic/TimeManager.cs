using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1F;
    }

    public void SetTimeScaleTo(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
