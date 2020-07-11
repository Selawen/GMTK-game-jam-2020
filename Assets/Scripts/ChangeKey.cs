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
    public Dictionary<int, string> keycodeNames { get; private set; } = new Dictionary<int, string>();
private int randomKey;

    private GUI UIManager;

    // Start is called before the first frame update
    void Start()
    {

        usableKeycodes = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M,
                                        KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Space,
                                        KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9,
                                        KeyCode.Tab, KeyCode.Return, KeyCode.Backspace, KeyCode.CapsLock, KeyCode.Escape, KeyCode.Quote, KeyCode.Comma, KeyCode.Minus, KeyCode.Period, KeyCode.Slash, KeyCode.Backslash, KeyCode.Semicolon, KeyCode.Equals, KeyCode.BackQuote,
                                        KeyCode.LeftAlt, KeyCode.LeftControl, KeyCode.LeftShift, KeyCode.LeftBracket,KeyCode.RightBracket, KeyCode.RightAlt, KeyCode.RightControl, KeyCode.RightShift};

        KeyToString();

        up = KeyCode.W;
        down = KeyCode.S;
        right = KeyCode.D;
        left = KeyCode.A;
        jump = KeyCode.Space;
        pause = KeyCode.Escape;

        UIManager = GameObject.Find("EventSystem").GetComponent<GUI>();
    }

    /// <summary>
    /// make ditionary to get "nice" names for keycodes 
    /// </summary>
    private void KeyToString()
    {
        foreach (KeyCode k in usableKeycodes)
        {
            keycodeNames.Add((int)k, k.ToString());
        }
        // replace Alpha0, Alpha1, .. and Keypad0... with "0", "1", ...
        for (int i = 0; i < 10; i++)
        {
                keycodeNames[((int)KeyCode.Alpha0 + i)] = i.ToString();
        }
            keycodeNames[(int)KeyCode.Comma] = ",";
            keycodeNames[(int)KeyCode.Escape] = "Esc";
            keycodeNames[(int)KeyCode.UpArrow] = "Up";
            keycodeNames[(int)KeyCode.DownArrow] = "Down";
            keycodeNames[(int)KeyCode.LeftArrow] = "Left";
            keycodeNames[(int)KeyCode.RightArrow] = "Right";
            keycodeNames[(int)KeyCode.CapsLock] = "Caps";
            keycodeNames[(int)KeyCode.Minus] = "-";
            keycodeNames[(int)KeyCode.Period] = ".";
            keycodeNames[(int)KeyCode.Quote] = "'";
            keycodeNames[(int)KeyCode.BackQuote] = "~";
            keycodeNames[(int)KeyCode.Slash] = "/";
            keycodeNames[(int)KeyCode.Backslash] = "\\";
            keycodeNames[(int)KeyCode.Semicolon] = ";";
            keycodeNames[(int)KeyCode.Equals] = "=";
            keycodeNames[(int)KeyCode.Backspace] = "Bksp";
            keycodeNames[(int)KeyCode.LeftAlt] = "Left Alt";
            keycodeNames[(int)KeyCode.LeftControl] = "Left Ctrl";
            keycodeNames[(int)KeyCode.LeftShift] = "Left Shift";
            keycodeNames[(int)KeyCode.LeftBracket] = "[";
            keycodeNames[(int)KeyCode.RightBracket] = "]";
            keycodeNames[(int)KeyCode.RightAlt] = "Right Alt";
            keycodeNames[(int)KeyCode.RightControl] = "Right Ctrl";
            keycodeNames[(int)KeyCode.RightShift] = "Right Shift";
    }


    public void RandomKey()
    {
        switch ((int)Random.Range(0, 5.9f))
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


        //Debug.Log(usableKeycodes[randomKey]);
    }
}
