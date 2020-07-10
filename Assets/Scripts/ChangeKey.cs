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

    KeyCode[] usableKeycodes;
    // Start is called before the first frame update
    void Start()
    {
        usableKeycodes = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T,  KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
        up = KeyCode.W;
        down = KeyCode.S;
        right = KeyCode.D;
        left = KeyCode.A;
        jump = KeyCode.Space;
    }


    public void RandomKey()
    {
        switch (Random.Range(0, 4))
        {
            case (0):

                break;
        }

    }
}
