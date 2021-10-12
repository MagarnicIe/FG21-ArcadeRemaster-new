using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    
    public int totalHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    
    void Update()
    {
        for (var i = 0; i < hearts.Length; i++)
        {
            if (i < FindObjectOfType<PlayerStatus>().health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < totalHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
