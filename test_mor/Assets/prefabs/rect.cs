using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rect : MonoBehaviour,RectItrf {

    public enum baseSideType { up,down,left,right,none};
    public delegate Vector3 DchangeSize(Vector2 ds);
    public delegate Vector3 DchangePos(Vector2 dp, Vector3 pos, Vector3 scale);
    public delegate Vector3 DboundsScale(Vector3 scale);
    public delegate Vector3 DboundsePos(Vector3 pos);
 
    List<RectItrf> childObj;
    public GameObject parent;
    public GameObject workFlow;
    public baseSideType baseSide = baseSideType.none;
    public bool baseSideOuter = true;

    mouseControl mCtrl;

    public Vector2 boundMin;
    public Vector2 boundMax;
    public enum rectType { horizontal,vertical};
    public rectType type = rectType.vertical;
    private Vector3 startPos;
    public bool fixMove = false;

    DchangeSize changeSize;
    DchangePos changePos;
    DboundsScale controlBoundsScale;
    DboundsePos controlBoundsPos;

    rectPosControl CPosControl;
    rectSizeControl CSizeControl;
    boundsScale CboundsScale;
    boundsPos CboundsPos;

    borderShow border;

     /**************************************************************************************
    **************************************************************************************/
   void OnMouseDown() {
        if(!fixMove)onMouse();        
    }

     /**************************************************************************************
    **************************************************************************************/
   public void onMouse() {
        mCtrl.start();
        Debug.Log("onMouse");
    }

   /**************************************************************************************
   **************************************************************************************/
    void configDelegateFunctions(){
        CPosControl  = new rectPosControl();
        CSizeControl = new rectSizeControl();
        CboundsScale = new boundsScale();
        CboundsPos   = new boundsPos();
        changeSize = CSizeControl.GetSizeDelegate(baseSide, baseSideOuter);
        changePos  = CPosControl.GetPosDelegate(baseSide, baseSideOuter, parent);
        controlBoundsScale = CboundsScale.GetDelegate(this);
        controlBoundsPos   = CboundsPos.GetDelegate(this);

    }

    /**************************************************************************************
    **************************************************************************************/
	void Start () {
        configDelegateFunctions();
        mCtrl = new mouseControl(this.gameObject);
        if(parent != null) parent.GetComponent<rect>().connectChild(this);
	}
	
    /**************************************************************************************
    **************************************************************************************/
	void Update () {
        if(mCtrl != null) mCtrl.update();
	}

    /**************************************************************************************
    **************************************************************************************/
   void touch_down() {
       if (border == null) border = new borderShow(this);
       border.enable();
    }

    /**************************************************************************************
    **************************************************************************************/
    void touch_up() {
        if (border != null) border.disable();
    }

    /**************************************************************************************
    **************************************************************************************/
    void touch_move(Vector2 shift) {

        transform.localScale = controlBoundsScale(transform.localScale + changeSize(shift));
        transform.position   = controlBoundsPos(changePos(shift, transform.position, transform.localScale));

        if (childObj != null) {
            foreach (RectItrf ri in childObj) {
                ri.parentChangePosition(transform.position);
            }
        }

        if (border != null) border.update();
    }

 
    /**************************************************************************************
    **************************************************************************************/

    /// RectItrf implementation
    public void connectChild(RectItrf go) {
        if(childObj == null) childObj = new List<RectItrf>();
        childObj.Add(go);        
    }

    public Vector3 parentChangePosition(Vector3 newPosition) {

        transform.localScale = controlBoundsScale(transform.localScale);
        transform.position = controlBoundsPos(changePos(new Vector2(0,0), transform.position, transform.localScale));
        if (border != null) border.update();

        return newPosition;
    }
}
