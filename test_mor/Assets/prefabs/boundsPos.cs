using UnityEngine;
using System.Collections;

public class boundsPos{
    rect rt;

    /**************************************************************************************
     **************************************************************************************/
    public rect.DboundsePos GetDelegate(rect rt) {
        this.rt = rt;
        if (rt.baseSideOuter) {
            switch (rt.baseSide) {
                //case rect.baseSideType.up: return boundsPosUpOuter;
                //case rect.baseSideType.down: return boundsPosDownOuter;
                case rect.baseSideType.right: return boundsPosRightOuter;
                case rect.baseSideType.left: return boundsPosLeftOuter;
            }
        } else {
            switch (rt.baseSide) {
                //case rect.baseSideType.up: return boundsPosUpIner;
                case rect.baseSideType.down: return boundsPosDownIner;
                //case rect.baseSideType.right: return boundsPosRightIner;
                //case rect.baseSideType.left: return boundsPosLeftIner;
            }
        }
        return null;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 boundsPosLeftOuter(Vector3 pos) {

        float max = rt.parent.renderer.bounds.max.y;
        float min = rt.workFlow.renderer.bounds.min.y;
        float width = rt.renderer.bounds.max.y - rt.renderer.bounds.min.y;

        pos.y = Mathf.Clamp(pos.y, min + width/2, max - width/2);

        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 boundsPosRightOuter(Vector3 pos) {

        float max = rt.parent.renderer.bounds.max.y;
        float min = rt.workFlow.renderer.bounds.min.y;
        float width = rt.renderer.bounds.max.y - rt.renderer.bounds.min.y;

        pos.y = Mathf.Clamp(pos.y, min + width/2, max - width/2);

        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 boundsPosDownIner(Vector3 pos) {
        float max = rt.parent.renderer.bounds.max.x;
        float min = rt.parent.renderer.bounds.min.x;
        float width = rt.renderer.bounds.max.x - rt.renderer.bounds.min.x;

        pos.x = Mathf.Clamp(pos.x, min + width / 2, max - width / 2);

        return pos;
    }

}
