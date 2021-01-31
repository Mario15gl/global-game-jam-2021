using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Use this for initialization
        void Awake()
        {
            //Set Cursor to not be visible
            Cursor.visible = false;
        }
}
