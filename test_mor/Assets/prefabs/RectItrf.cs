using UnityEngine;
using System.Collections;

public interface RectItrf {
    void connectChild(RectItrf go);
    Vector3 parentChangePosition(Vector3 newPosition);
}
