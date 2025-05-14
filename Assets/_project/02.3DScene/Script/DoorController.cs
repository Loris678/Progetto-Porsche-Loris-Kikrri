using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<Transform> porte; // Ordine: Ant. SX, Post. SX, Ant. DX, Post. DX
    public float velocitaRotazione = 1.0f;

    private List<Quaternion> rotazioniChiuse = new List<Quaternion>();
    private List<Quaternion> rotazioniAperte = new List<Quaternion>();
    private List<Quaternion> rotazioniObiettivo = new List<Quaternion>();
    private bool aperte = false;

    void Start()
    {
        rotazioniChiuse.Clear();
        rotazioniAperte.Clear();
        rotazioniObiettivo.Clear();

        for (int i = 0; i < porte.Count; i++)
        {
            Quaternion rotChiuso = porte[i].localRotation;
            rotazioniChiuse.Add(rotChiuso);

            // Modifica direzione: ora le porte si aprono verso l'esterno
            Quaternion rotAperta = rotChiuso * Quaternion.Euler(0f, (i <= 1 ? 50f : -50f), 0f);
            rotazioniAperte.Add(rotAperta);

            rotazioniObiettivo.Add(rotChiuso);
        }
    }

    void Update()
    {
        for (int i = 0; i < porte.Count; i++)
        {
            porte[i].localRotation = Quaternion.Lerp(
                porte[i].localRotation,
                rotazioniObiettivo[i],
                Time.deltaTime * velocitaRotazione
            );
        }
    }

    public void TogglePorte()
    {
        aperte = !aperte;

        for (int i = 0; i < porte.Count; i++)
        {
            rotazioniObiettivo[i] = aperte ? rotazioniAperte[i] : rotazioniChiuse[i];
        }

        Debug.Log("Porte: " + (aperte ? "aperte" : "chiuse"));
    }
}
