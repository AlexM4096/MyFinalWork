using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBanner
{
    public void Resize(int width, int height);
    
    public void Resize(Vector2Int size);

    public Vector2Int Size();

    public void Reposition(int x, int y);
    
    public void Reposition(Vector2Int position);

    public Vector2Int Position();

    public void SetActive(bool state);
}
