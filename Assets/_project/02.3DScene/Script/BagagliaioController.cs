using UnityEngine;

public class BagagliaioController : MonoBehaviour
{
    public Transform bagagliaio;
    public float velocitaRotazione = 1.2f;

    private Quaternion chiuso;
    private Quaternion aperto;
    private Quaternion obiettivo;
    private bool isAperto = false;

    void Start()
    {
        chiuso = bagagliaio.localRotation;
        aperto = chiuso * Quaternion.Euler(70f, 0f, 0f); // Corretto: si apre verso l'alto
        obiettivo = chiuso;
    }

    void Update()
    {
        bagagliaio.localRotation = Quaternion.Lerp(
            bagagliaio.localRotation,
            obiettivo,
            Time.deltaTime * velocitaRotazione
        );
    }

    public void Toggle()
    {
        isAperto = !isAperto;
        obiettivo = isAperto ? aperto : chiuso;
    }
}