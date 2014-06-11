using UnityEngine;
using System.Collections;

public class rectPosControl {
    GameObject parentObj;
    rect.baseSideType side;
    bool baseSideOuter;

    /**************************************************************************************
     **************************************************************************************/
    public rect.DchangePos GetPosDelegate(rect.baseSideType side, bool baseSideOuter, GameObject parent) {
        parentObj = parent;
        this.side = side;
        this.baseSideOuter = baseSideOuter;

        if (baseSideOuter) {
            switch (side) {
                case rect.baseSideType.up: return ChangePosUpOuter;
                case rect.baseSideType.down: return ChangePosDownOuter;
                case rect.baseSideType.right: return ChangePosRightOuter;
                case rect.baseSideType.left: return ChangePosLeftOuter;
            }
        } else {
            switch (side) {
                case rect.baseSideType.up: return ChangePosUpIner;
                case rect.baseSideType.down: return ChangePosDownIner;
                case rect.baseSideType.right: return ChangePosRightIner;
                case rect.baseSideType.left: return ChangePosLeftIner;
            }
        }
        return null;
    }

    /**************************************************************************************
     **************************************************************************************/
    Vector3 ChangePosUpOuter(Vector2 ds, Vector3 pos, Vector3 scale) {
        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 ChangePosDownOuter(Vector2 ds, Vector3 pos, Vector3 scale) {
        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 ChangePosLeftOuter(Vector2 ds, Vector3 pos, Vector3 scale) {
        
        float baseX = parentObj.renderer.bounds.min.x;
        float sizeX = scale.x;
        pos.x = baseX - sizeX/2;
        pos.y += ds.y;
        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 ChangePosRightOuter(Vector2 ds, Vector3 pos, Vector3 scale) {
        float baseX = parentObj.renderer.bounds.max.x;
        float sizeX = scale.x;
        pos.x = baseX + sizeX/2;
        pos.y += ds.y;
        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 ChangePosUpIner(Vector2 ds, Vector3 pos, Vector3 scale) {
        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 ChangePosDownIner(Vector2 ds, Vector3 pos, Vector3 scale) {

        float baseY = parentObj.renderer.bounds.min.y;
        float sizeY = scale.y;
        pos.y = baseY + sizeY / 2;
        pos.x -= ds.x;
        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 ChangePosLeftIner(Vector2 ds, Vector3 pos, Vector3 scale) {
        return pos;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3 ChangePosRightIner(Vector2 ds, Vector3 pos, Vector3 scale) {
        return pos;
    }

}
