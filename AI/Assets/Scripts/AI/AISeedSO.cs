using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Seed")]
public class AISeedSO : ScriptableObject
{
    public float priority = 0;
    public List<Vector3> seeds = new List<Vector3>();
}
