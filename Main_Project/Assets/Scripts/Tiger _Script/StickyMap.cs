using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Toad_Green_Brown")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name == "Toad_Green_Brown")
    //    {
    //        collision.gameObject.transform.SetParent(null);
    //    }
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Toad_Green_Brown")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
