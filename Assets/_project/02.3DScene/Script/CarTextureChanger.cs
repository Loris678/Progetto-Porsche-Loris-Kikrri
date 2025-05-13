using UnityEngine;
using UnityEngine.UI;

public class CarTextureChanger : MonoBehaviour
{
    [Header("Target")]
    public Transform carRoot; // Oggetto padre della macchina

    [Header("UI Buttons")]
    public Button[] textureButtons;

    [Header("Texture Names (senza estensione)")]
    public string[] textureNames;

    private Renderer[] carRenderers;
    private int currentTextureIndex = -1; // Nessuna texture applicata all'inizio

    private void Start()
    {
        carRenderers = carRoot.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < textureButtons.Length; i++)
        {
            int index = i;
            textureButtons[i].onClick.AddListener(() => ToggleTexture(index));
        }
    }

    void ToggleTexture(int index)
    {
        // Se stiamo cliccando di nuovo sulla texture già applicata: rimuovila
        if (currentTextureIndex == index)
        {
            ClearTexture();
            currentTextureIndex = -1;
            Debug.Log("Wrap rimosso");
        }
        else
        {
            string path = textureNames[index];
            Debug.Log("Cerco texture in: Resources/" + path);
            Texture2D newTexture = Resources.Load<Texture2D>(path);

            if (newTexture != null)
            {
                foreach (Renderer rend in carRenderers)
                {
                    if (rend.sharedMaterial.HasProperty("_BaseMap"))
                        rend.sharedMaterial.SetTexture("_BaseMap", newTexture);
                    else if (rend.sharedMaterial.HasProperty("_MainTex"))
                        rend.sharedMaterial.SetTexture("_MainTex", newTexture);
                }

                currentTextureIndex = index; // Memorizza l’indice della texture applicata
                Debug.Log("Wrap applicato: " + path);
            }
            else
            {
                Debug.LogWarning("Texture non trovata: " + path);
            }
        }
    }

    public void ClearTexture()
    {
        foreach (Renderer rend in carRenderers)
        {
            if (rend.sharedMaterial.HasProperty("_BaseMap"))
                rend.sharedMaterial.SetTexture("_BaseMap", null);
            else if (rend.sharedMaterial.HasProperty("_MainTex"))
                rend.sharedMaterial.SetTexture("_MainTex", null);
        }
    }
}