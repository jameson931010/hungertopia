using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public static class HexMetrix 
{
    public static float OuterRadius (float hexSize)
    {
        return hexSize;
    }

    public static float InnerRadius (float hexSize)
    {
        return hexSize*0.866025404f;
    }

    public static Vector3 Center(float hexSize, int x, int z, HexOrientation orientation)
    {
        Vector3 centerPosition;
        if(orientation == HexOrientation.PointyTop)
        {
            centerPosition.x = (x+z*0.5f-z/2) * (InnerRadius(hexSize)*2f);
            centerPosition.y = 0f;
            centerPosition.z = z * (OuterRadius(hexSize)*1.5f);
        }
        else
        {
            centerPosition.x = x*(OuterRadius(hexSize)*1.5f);
            centerPosition.y = 0f;
            centerPosition.z = (z+x*0.5f-x/2) * (InnerRadius(hexSize)*2f);
        }
        return centerPosition;
    }
    public static Vector3 Corner(float hexSize, HexOrientation orientation, int index)
    {
        float angle = 60f * index;
        if(orientation == HexOrientation.PointyTop)
        {
            angle += 30f;
        }
        Vector3 corner = new Vector3(hexSize*Mathf.Cos(angle*Mathf.Deg2Rad), 0f, hexSize*Mathf.Sin(angle*Mathf.Deg2Rad));
        return corner;
    }

    public static Vector3[] Corners (float hexSize, HexOrientation orientation)
    {
        Vector3[] corners = new Vector3[6];
        for (int i=0; i<6; i++)
        {
            corners[i] = Corner(hexSize, orientation, i);
        }
        return corners;
    }

    public static Vector3 OffsetToCube(int x, int z, HexOrientation orientation)
    {
        Vector3 Cube;
        if(orientation == HexOrientation.PointyTop)
        {
            Cube.x = x - (z-(z&1))/2;           //lower left - upper right
            Cube.y = x + (z+(z&1))/2;           //upper left - lower right
            Cube.z = z;
        }
        else
        {
            Cube.x = x;
            Cube.y = z - (x-(x&1))/2;           //lower left - upper right
            Cube.z = z + (x+(x&1))/2;           //upper left - lower right
        }
        return Cube;
    }
    
}
