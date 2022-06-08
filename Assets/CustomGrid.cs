using UnityEngine;
using UnityEngine.Tilemaps;

public class CustomGrid : MonoBehaviour
{
    private Grid _grid;
    [SerializeField] private Tilemap _groundMap, _levelMap, _interactiveMap;
    [SerializeField] private Camera _camera;
    [SerializeField] private Tile _hoverTile;
    [SerializeField] private RuleTile _pathTile;

    private Vector3Int _previousCoordinates;
    
    
    private Vector3Int GetMousePosition () => _grid.WorldToCell(_camera.ScreenToWorldPoint(Input.mousePosition));

    void Awake()
    {
        _grid = GetComponent<Grid>();
    }
    
    private void Update() {
        var mousePosition = GetMousePosition();
        
        if (!_previousCoordinates.Equals(mousePosition))
        {
            _interactiveMap.SetTile(_previousCoordinates, null);
            _interactiveMap.SetTile(mousePosition, _hoverTile);
            _previousCoordinates = mousePosition;
        }

        Debug.Log(mousePosition);
    }
    
}
