using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this is going to read joystick inputs or movement input and return specific value and basically manage if we are flippng between movements
public class NewBehaviourScript : MonoBehaviour
{
    public static float x, y;
    static bool x_down, y_down;
    // Start is called before the first frame update
    void Start()
    {
        x = 0; y = 0;
        x_down = false; y_down = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(ref x, ref x_down, "Horizontal");
        GetInput(ref y, ref y_down, "Vertical");
    }

    void GetInput (ref float val, ref bool down, string axis)
    {
        float input = Input.GetAxisRaw(axis); // gets the input from the axis
        input = (input > 0) ? 1 : ((input < 0) ? -1 : 0); //forces input to be 1, -1 or 0
        if (input != val)
        {
            val = input;
            down = (val != 0) ? true : false;
        }
        else
            down = false;
    }

    public static bool InputDownX()
    {
        return x_down;
    }
    public static bool InputDownY()
    {
        return y_down;
    }
}
