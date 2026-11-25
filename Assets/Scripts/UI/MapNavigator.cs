using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNavigator : MonoBehaviour
{
    [SerializeField] GameObject mapPanel;

    bool open;

    private void Awake()
    {
        ToggleMap(false);
    }

    private void Update()
    {
        if (open) return;

        if (InputManager.Instance.mapKey.WasPressedThisFrame())
            ToggleMap(true);
    }

    public void ToggleMap(bool toggle)
    {
        open = toggle;
        mapPanel.SetActive(toggle);
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
