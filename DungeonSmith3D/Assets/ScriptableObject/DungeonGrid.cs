using UnityEngine;

[CreateAssetMenu(fileName = "DungeonGrid", menuName = "Scriptable Objects/DungeonGrid")]
public class DungeonGrid : ScriptableObject
{
    [SerializeField] private int _gridSizeX;

    [SerializeField] private int _gridSizeZ;

    [SerializeField] private float _nodeSize = 10;

    

    public int GridSizeX => _gridSizeX;
    public int GridSizeZ => _gridSizeZ;
    public float NodeSize => _nodeSize;
}
