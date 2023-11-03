using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerCollection : MonoBehaviour
{
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] TMP_Text Pink_Count;
    [SerializeField] TMP_Text Blue_Count;
    [SerializeField] TMP_Text Yellow_Count;

    private void Start()
    {
        PlayerPrefs.SetInt("FlowerCount", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bee") || collision.gameObject.CompareTag("Toad"))
        {
            Destroy(gameObject);
            AudioManager.PlaySFX(AudioManager.Collection_Items);
            PlayerPrefs.SetInt("FlowerCount", PlayerPrefs.GetInt("FlowerCount") + 1);
            if (PlayerPrefs.GetInt("FlowerCount") == 1)
            {
                Pink_Count.SetText("x " + PlayerPrefs.GetInt("FlowerCount"));
            }else if(PlayerPrefs.GetInt("FlowerCount") == 2 || PlayerPrefs.GetInt("FlowerCount") == 3)
            {
                Blue_Count.SetText("x " + (PlayerPrefs.GetInt("FlowerCount") - 1));
            }
            else if(PlayerPrefs.GetInt("FlowerCount") == 4 || PlayerPrefs.GetInt("FlowerCount") == 5 || PlayerPrefs.GetInt("FlowerCount") == 6)
            {
                Yellow_Count.SetText("x " + (PlayerPrefs.GetInt("FlowerCount") - 3));
            }
        }
    }
}
