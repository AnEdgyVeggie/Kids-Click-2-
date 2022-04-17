using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;
    [SerializeField]
    Color[] buttonColor;

    Color yellow;

    [SerializeField]
    Text win, color;

    bool _canWin = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        yellow = buttons[8].image.color;

        Debug.LogWarning(yellow);
        Debug.LogWarning(yellow == buttons[8].image.color);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.color = buttonColor[i];
            if (buttons[i].image.color == Color.white ||
                buttons[i].image.color == Color.green ||
                buttons[i].image.color == yellow ||
                buttons[i].image.color == Color.cyan)
            {
                buttons[i].GetComponentInChildren<Text>().color = Color.black;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].image.color == Color.white ||
                buttons[i].image.color == Color.green ||
                buttons[i].image.color == Color.yellow ||
                buttons[i].image.color == Color.cyan)
            {
                buttons[i].GetComponentInChildren<Text>().color = Color.black;
            }
            else
            {
                buttons[i].GetComponentInChildren<Text>().color = Color.white;
            }
        }
    }

    public void DisplayButtonColors()
    {
        foreach (Color button in buttonColor) { Debug.LogWarning(button); }
    }

    private bool testfunction(Color color){
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].image.color != color)
            {
                return false;
            }
        }
        return true;

    }


    public Color[] GetButtonsColor()
    {
        return buttonColor;

    }

    public void CheckButtons(Color color)
    {
        if (testfunction(color))
        {
            GameWin(color);
        }
    }

    void GameWin(Color finalColor)
    {
        win.text = "YOU WIN " +
            "All Colors are";
        color.text = "The Same!";
        color.color = finalColor;
        anim.SetTrigger("WinGame");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }

}
