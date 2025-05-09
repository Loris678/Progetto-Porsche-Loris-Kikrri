using UnityEngine;

public class CloseApp : MonoBehaviour
{
    // Funzione per chiudere l'app
    public void CloseApplication()
    {
        // Per editor Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
