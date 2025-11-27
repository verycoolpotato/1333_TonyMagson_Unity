using DiceGame.Scripts.Creatures;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTable", menuName = "Scriptable Objects/EnemyTable")]
public class EnemyTable : ScriptableObject
{
    [SerializeField] private Enemy[] Tables;



    public Enemy[] TableArray => Tables;

}
