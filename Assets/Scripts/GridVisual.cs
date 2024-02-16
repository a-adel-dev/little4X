using UnityEngine;

public class GridVisual : MonoBehaviour
{
    [SerializeField] private GameObject gridVisual;
    
    public void ShowGridVisual()
    {
        gridVisual.SetActive(true);
    }

    public void HideGridVisual()
    {
        gridVisual.SetActive(false);
    }
}
