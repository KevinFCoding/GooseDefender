using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color _hoverColor;
    [SerializeField] Vector3 _turretPositionOffset;

    private GameObject _turret;

    private Renderer _renderer;
    private Color _startColor;

    BuildManager _buildManager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;

        _buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_buildManager.GetTurretToBuild() == null)
            return;

        if (_turret != null)
        {
            Debug.Log("Can't build there ! - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = _buildManager.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + _turretPositionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_buildManager.GetTurretToBuild() == null)
            return;
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
