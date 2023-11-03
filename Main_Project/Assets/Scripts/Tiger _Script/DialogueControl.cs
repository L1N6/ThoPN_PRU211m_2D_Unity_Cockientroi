using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    [SerializeField] private Health healthCount;
    public GameObject tigerDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCount.currenthealth == 0)
        {
            tigerDialog.SetActive(true);
        }
    }
}
