using UnityEngine;
using System.Collections;

public class mouseControl {
    private GameObject  parent;
    private Vector3 mouseOld;
    private bool inControl = false;
    private Vector2 sense ;

    Vector2 configSense() {
        return new Vector2(0.01f,0.01f);
    }
    public mouseControl(GameObject go) {
        this.parent = go;
        sense = configSense();
    }

    public void start() {
        mouseOld = Input.mousePosition;
        parent.SendMessage("touch_down");        
        inControl = true;
    }

    public void update() {
        if (Input.GetMouseButtonUp(0)) {
            parent.SendMessage("touch_up");
            inControl = false;
        }
        if (inControl) {
            Vector3 mouseCur = Input.mousePosition;
            Vector3 dm =  mouseCur - mouseOld; 
            mouseOld = mouseCur;
            if (dm.x != 0 || dm.y != 0) {
                parent.SendMessage("touch_move",new Vector2((-1)*dm.x*sense.x,dm.y*sense.y));
            }
        }
    }
}
