using UnityEngine;
using Vuforia;

public class Config : MonoBehaviour
{
    private void Start()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
