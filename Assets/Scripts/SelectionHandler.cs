using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionHandler : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    List<Cell> selected = new List<Cell>(); // подсвеченые клетки

    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && gameManager.IsTurnHuman())
        {
            DeselectedCell();
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame && gameManager.IsTurnHuman())
        {   
            SelectCell();
        }
    }

    private void SelectCell()
    {
        Vector2 ray = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if (!hit) { return; }

        if (!hit.collider.TryGetComponent<Cell>(out Cell cell)) { return; }

        selected = gameManager.ClickOnCell(cell.Position);

        for (int i=0; i<selected.Count; i++)
        {
            selected[i].Select();
        }

    }

    private void DeselectedCell()
    {
        for (int i = 0; i < selected.Count; i++)
        {
            selected[i].Deselect();
        }

        selected.Clear();
    }
}
