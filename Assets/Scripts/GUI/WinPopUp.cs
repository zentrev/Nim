using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopUp : Window
{
    public void Replay()
    {
        SceneSwitcher.Instance.LoadScene("Game");
    }

    public void Menu()
    {
        SceneSwitcher.Instance.LoadScene("Menu", SceneSwitcher.eSet.MENU);
    }
}
