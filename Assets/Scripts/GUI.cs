using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{
    public TextMeshProUGUI keysText;
    private ChangeKey changedKeys;

    // Start is called before the first frame update
    void Awake()
    {
        changedKeys = GameObject.Find("InputManager").GetComponent<ChangeKey>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKeyText()
    {
        changedKeys = GameObject.Find("InputManager").GetComponent<ChangeKey>();

        keysText.text = "Up: " + changedKeys.keycodeNames[(int)changedKeys.up] + "<br>" +
                        "Down: " + changedKeys.keycodeNames[(int)changedKeys.down] + "<br>" + 
                        "Left: " + changedKeys.keycodeNames[(int)changedKeys.left] + "<br>" + 
                        "Right: " + changedKeys.keycodeNames[(int)changedKeys.right] + "<br>" + 
                        "Jump: " + changedKeys.keycodeNames[(int)changedKeys.jump] + "<br>" + 
                        "Pause: " + changedKeys.keycodeNames[(int)changedKeys.pause] + "<br>";
    }
}
