using UnityEngine;

public static class CompareLayers
{
    public static bool CompareLayerAndMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
