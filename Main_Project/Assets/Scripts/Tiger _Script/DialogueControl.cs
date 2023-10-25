using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    private TigerDialog tigerDialog;
    GameObject dialog;
    // Start is called before the first frame update
    void Start()
    {
        tigerDialog = GetComponent<TigerDialog>();
        dialog = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
