using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Funzione per cambiare scena tramite il nome della scena
    public void ChangeScene(string sceneName)
    {
        // Carica la scena
        SceneManager.LoadScene(sceneName);
    }
}