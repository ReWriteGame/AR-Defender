using UnityEngine;
using Vuforia;

public class Config : MonoBehaviour
{
    void Start()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
