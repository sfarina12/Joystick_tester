using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utility : MonoBehaviour
{
    public List<KeyCode> bannedKeys;
    [HideInInspector]
    public bool isPressingBannedKey=false;

    private bool isKeyBanned(KeyCode key)
    {
        foreach (KeyCode k in bannedKeys)
            if (k.Equals(key))
                return true;
        
        return false;
    }
}
