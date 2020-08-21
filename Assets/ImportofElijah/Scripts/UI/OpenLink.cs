using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    public void OpenChannel()
    {
        Application.OpenURL("https://parsecgaming.com/features/");
    }
}
