using UnityEngine;

public class CursorStateManager : MonoBehaviour
{
    public void SetCursorStateLockedAndNotVisible()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetCursorsStateUnlockedAndVisible()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
