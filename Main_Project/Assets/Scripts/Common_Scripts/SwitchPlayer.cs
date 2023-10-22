using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] private GameObject ChangedPlayer;
    [SerializeField] private GameObject BeeAvatar;
    [SerializeField] private GameObject ToadAvatar;
    [SerializeField] private GameObject ToadName;
    [SerializeField] private GameObject BeeName;
    private Rigidbody2D rigidbody2D;
    private bool lockKeyCode = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !lockKeyCode)
        {
            changedPlayer(this.tag);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            lockKeyCode = true;

            Invoke("ResetLockKeyCode", 1.0f);
        }
    }

    private void ResetLockKeyCode()
    {
        lockKeyCode = false;
    }

    private void changedPlayer(string tag)
    {
        ChangedPlayer.transform.position = this.transform.position;
        this.gameObject.SetActive(false);
        ChangedPlayer.SetActive(true);
        switch (tag)
        {
            case "Toad":
                ToadName.SetActive(false);
                ToadAvatar.SetActive(false);
                BeeName.SetActive(true);
                BeeAvatar.SetActive(true);
                break;
            case "Bee":
                BeeName.SetActive(false);
                BeeAvatar.SetActive(false);
                ToadName.SetActive(true);
                ToadAvatar.SetActive(true);
                break;
        }
    }
}
