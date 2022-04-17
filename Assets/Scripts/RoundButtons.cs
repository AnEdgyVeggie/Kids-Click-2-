using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtons : MonoBehaviour
{
    [SerializeField]
    UIManager uiManager;
    Image image;
    Color[] colors;

    [SerializeField]
    Button button;

    private void Start()
    {
        image = this.GetComponent<Image>();
        colors = uiManager.GetButtonsColor();
    }

    public void ChangeColor()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            if (image.color == colors[i])
            {

                if (image.color == colors[colors.Length - 1])
                {
                    image.color = colors[0];
                    uiManager.CheckButtons(image.color);
                    return;
                }
                else
                {
                    image.color = (colors[i + 1]);
                    uiManager.CheckButtons(image.color);
                    return;
                }
            }
        }
    }


}
