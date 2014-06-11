using UnityEngine;
using System.Collections;

public class boundsScale{
    rect rt;
    float minSize = 0.3f;
      /**************************************************************************************
     **************************************************************************************/
    public rect.DboundsScale GetDelegate(rect rt) {
        this.rt = rt;
        if (rt.baseSideOuter) {
            switch (rt.baseSide) {
                //case rect.baseSideType.up: return boundsScaleUpOuter;
                //case rect.baseSideType.down: return boundsScaleDownOuter;
                case rect.baseSideType.right: return boundsScaleRightOuter;
                case rect.baseSideType.left: return boundsScaleLeftOuter;
            }
        } else {
            switch (rt.baseSide) {
                //case rect.baseSideType.up: return boundsScaleUpIner;
                case rect.baseSideType.down: return boundsScaleDownIner;
                //case rect.baseSideType.right: return boundsScaleRightIner;
                //case rect.baseSideType.left: return boundsScaleLeftIner;
            }
        }
        return null;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 boundsScaleLeftOuter( Vector3 scale) {
        float maxX = rt.parent.renderer.bounds.min.x;
        float minX = rt.workFlow.renderer.bounds.min.x;
        float size_min = minSize;
        float size_max = maxX - minX;
        scale.x = Mathf.Clamp(scale.x,size_min,size_max);
        return scale;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 boundsScaleRightOuter( Vector3 scale) {
        float maxX = rt.workFlow.renderer.bounds.max.x;
        float minX = rt.parent.renderer.bounds.max.x;
        float size_min = minSize;
        float size_max = maxX - minX;
        scale.x = Mathf.Clamp(scale.x,size_min,size_max);
        return scale;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 boundsScaleDownIner(Vector3 scale) {
        float maxY = rt.parent.renderer.bounds.max.y;
        float minY = rt.workFlow.renderer.bounds.min.y;
        float size_min = minSize;
        float size_max = maxY - minY;
        scale.y = Mathf.Clamp(scale.y, size_min, size_max);
        return scale;
    }

}
