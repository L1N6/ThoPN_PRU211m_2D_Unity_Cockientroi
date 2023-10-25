using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetAvatar : MonoBehaviour
{
    [SerializeField] private List<Image> imageList;
        
    public void SetAvatar(string avatarTag)
    {
        foreach (Image image in imageList)
        {
            image.gameObject.SetActive(false);
        }

        foreach (Image image in imageList)
        {
            if (image.name == avatarTag)
            {
                image.gameObject.SetActive(true);
                return;
            }
        }
    }
}
