using UnityEngine;
using System.Collections;

public class rectSizeControl {

    rect.baseSideType side;
    bool baseSideOuter;

    /**************************************************************************************
     **************************************************************************************/
    public rect.DchangeSize GetSizeDelegate(rect.baseSideType side, bool baseSideOuter) {

        this.side = side;
        this.baseSideOuter = baseSideOuter;

        if (baseSideOuter) {
            switch (side) {
                case rect.baseSideType.up: return ChangeSizeUpOuter;
                case rect.baseSideType.down: return ChangeSizeDownOuter;
                case rect.baseSideType.right: return ChangeSizeRightOuter;
                case rect.baseSideType.left: return ChangeSizeLeftOuter; 
            }
        } else {
            switch (side) {
                case rect.baseSideType.up: return ChangeSizeUpIner;
                case rect.baseSideType.down: return ChangeSizeDownIner;
                case rect.baseSideType.right: return ChangeSizeRightIner;
                case rect.baseSideType.left: return ChangeSizeLeftIner; 
            }
        }
        return null;
    }

    /**************************************************************************************
     **************************************************************************************/
    Vector3  ChangeSizeUpOuter(Vector2 ds) {
        return ds;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3  ChangeSizeDownOuter(Vector2 ds) {
        return ds;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3  ChangeSizeLeftOuter(Vector2 ds) {
        return new Vector3(ds.x,0,0);
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3  ChangeSizeRightOuter(Vector2 ds) {
        return new Vector3((-1)*ds.x,0,0);
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3  ChangeSizeUpIner(Vector2 ds) {
        return ds;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3  ChangeSizeDownIner(Vector2 ds) {
        return new Vector3(0,ds.y,0);
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3  ChangeSizeLeftIner(Vector2 ds) {
        return ds;
    }

    /**************************************************************************************
    **************************************************************************************/
    Vector3  ChangeSizeRightIner(Vector2 ds) {
        return ds;
    }

}
