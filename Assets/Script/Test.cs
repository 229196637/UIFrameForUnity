using UIFramwork;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        PanelManager.Instance.PopAndPush(new TestPanel());
    }
}
