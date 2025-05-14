using UnityEngine;

public class SportelloDestroController : MonoBehaviour
{
    public Transform sportello;
    public float velocitaRotazione = 1.5f;

    private Quaternion chiuso;
    private Quaternion aperto;
    private Quaternion obiettivo;
    private bool isAperto = false;

    void Start()
    {
        chiuso = sportello.localRotation;
        aperto = chiuso * Quaternion.Euler(0f, -60f, 0f); // -60° verso l'esterno
        obiettivo = chiuso;
    }

    void Update()
    {
        sportello.localRotation = Quaternion.Lerp(
            sportello.localRotation,
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