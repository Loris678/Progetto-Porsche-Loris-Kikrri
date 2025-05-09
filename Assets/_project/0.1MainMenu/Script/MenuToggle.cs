using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    public Button menuButton;
    public GameObject[] menuButtons;
    private bool isMenuOpen = false;

    void Start()
    {
        menuButton.onClick.AddListener(ToggleMenu);
        SetMenuButtonsActive(false);
    }

    void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        SetMenuButtonsActive(isMenuOpen);
    }

    void SetMenuButtonsActive(bool state)
    {
        foreach (GameObject button in menuButtons)
        {
            button.SetActive(state);
        }
    }
}