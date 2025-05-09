using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    // Lista dei materiali skybox (HDRI)
    public Material[] skyboxes;

    // Indice del materiale da usare appena parte la scena
    public int defaultIndex = 0;

    void Start()
    {
        // Imposta lo skybox iniziale
        SetSkybox(defaultIndex);
    }

    // Metodo per cambiare skybox (lo usano i pulsanti)
    public void SetSkybox(int index)
    {
        if (index >= 0 && index < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[index];
            DynamicGI.UpdateEnvironment(); // Aggiorna la luce nella scena
        }
        else
        {
            Debug.LogWarning("Indice skybox non valido: " + index);
        }
    }
}