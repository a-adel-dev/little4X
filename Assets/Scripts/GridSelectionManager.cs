using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSelectionManager : MonoBehaviour
{
    GridVisual gridVisual = null;

    void Update()
    {
        RaycastHit hit;
        gridVisual?.HideGridVisual();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            gridVisual = hit.transform.parent.GetComponent<GridVisual>();
            if (gridVisual is null) return;
            gridVisual.ShowGridVisual();
        }
    }
}
