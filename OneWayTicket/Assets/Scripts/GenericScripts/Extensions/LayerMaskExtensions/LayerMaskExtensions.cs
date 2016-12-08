using UnityEngine;
using Enums;
using System.Linq;

public static class LayerMaskExtensions
{
    //Creates a LayerMask from that includes the layers sent as parameters
    public static LayerMask LayerMaskFromLayers(params Layer[] args)
    {
        return LayerMaskFromLayers(args.Cast<int>().ToArray());
    }

    public static LayerMask LayerMaskFromLayers(params int[] args)
    {
        Debug.Assert(args.Length > 0);
        LayerMask returnMask = new LayerMask();
        foreach(int arg in args)
        {
            returnMask |= (1 << arg);
        }
        return returnMask;
    }

    //Creates a LayerMask from that excludes the layers sent as parameters
    public static LayerMask LayerMaskExcludingLayers(params Layer[] args)
    {
        return LayerMaskExcludingLayers(args.Cast<int>().ToArray());
    }
    public static LayerMask LayerMaskExcludingLayers(params int[] args)
    {
        return ~LayerMaskFromLayers(args);
    }
}
