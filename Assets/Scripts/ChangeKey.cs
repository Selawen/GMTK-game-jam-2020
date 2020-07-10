using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKey : MonoBehaviour
{
    public KeyCode up { get; private set; }
    public KeyCode down { get; private set; }
    public KeyCode right { get; private set; }
    public KeyCode left { get; private set; }
    public KeyCode jump { get; private set; }
    public KeyCode pause { get; private set; }

    KeyCode[] usableKeycodes;
    private int randomKey;

    private GUI UIManager;

    // Start is called before the first frame update
    void Start()
    {
        usableKeycodes = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M,
                                        KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow,
                                        KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9,
                                        KeyCode.Tab, KeyCode.Return, KeyCode.Backspace, KeyCode.CapsLock, KeyCode.Escape, KeyCode.Quote, KeyCode.Comma, KeyCode.Minus, KeyCode.Period, KeyCode.Slash, KeyCode.Semicolon, KeyCode.Equals, KeyCode.Tilde,
                                        KeyCode.LeftAlt, KeyCode.LeftControl, KeyCode.LeftShift, KeyCode.RightBracket, KeyCode.RightAlt, KeyCode.RightControl, KeyCode.RightShift, KeyCode.RightBracket};
        up = KeyCode.W;
        down = KeyCode.S;
        right = KeyCode.D;
        left = KeyCode.A;
        jump = KeyCode.Space;

        UIManager = GameObject.Find("EventSystem").GetComponent<GUI>();
    }


    public void RandomKey()
    {
        switch (Random.Range(0, 5))
        {
            case (0):
                do {
                    randomKey = Random.Range(0, usableKeycodes.Length);
                }
                while (usableKeycodes[randomKey] == up);
                up = usableKeycodes[randomKey];
                break;
            case (1):
                do
                {
                    randomKey = Random.Range(0, usableKeycodes.Length);
                }
                while (usableKeycodes[randomKey] == down);
                down = usableKeycodes[randomKey];
                break;
            case (2):
                do
                {
                    randomKey = Random.Range(0, usableKeycodes.Length);
                }
                while (usableKeycodes[randomKey] == right);
                right = usableKeycodes[randomKey];
                break;
            case (3):
                do
                {
                    randomKey = Random.Range(0, usableKeycodes.Length);
                }
                while (usableKeycodes[randomKey] == left);
                left = usableKeycodes[randomKey];
                break;
            case (4):
                do
                {
                    randomKey = Random.Range(0, usableKeycodes.Length);
                }
                while (usableKeycodes[randomKey] == jump);
                jump = usableKeycodes[randomKey];
                break;
            case (5):
                do
                {
                    randomKey = Random.Range(0, usableKeycodes.Length);
                }
                while (usableKeycodes[randomKey] == pause);
                pause = usableKeycodes[randomKey];
                break;
        }

        UIManager.UpdateKeyText();


        Debug.Log(usableKeycodes[randomKey]);
    }
}
