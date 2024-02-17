using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [field:SerializeField] public HexOrientation Orientation { get; private set; }
    [field:SerializeField] public int Width { get; private set; }
    [field:SerializeField] public int Height { get; private set; }
    [field:SerializeField] public int HexSize { get; private set; }
    [field:SerializeField] public int HexPrefab { get; private set; }

    private void OnDrawGizmos()
    {
        for(int z=0; z<Height; z++)
        {
            for(int x=0; x<Width; x++)
            {
                Vector3 centerPosition = HexMetric.Center(HexSize, x, z, Orientation) + transform.position;
                for(int s=0; s<HexMetric.Corners(HexSize,Orientation).Length; s++)
                {
                    Gizmos.DrawLine(
                        centerPosition+HexMetric.Corners(HexSize, Orientation)[s%6],
                        centerPosition+HexMetric.Corners(HexSize, Orientation)[(s+1)%6]
                    );
                }
            }
        }
    }
}

public enum HexOrientation
{
    FlatTop,
    PointyTop
}
