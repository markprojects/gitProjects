using UnityEngine;
using System.Collections;

public class borderShow {
    private rect rect;
    LineRenderer lr;
    float z_pos = -0.3f;

    public borderShow(rect rect) {        
        this.rect = rect;

        lr = rect.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Diffuse"));
        lr.SetColors(Color.red, Color.red);
        lr.SetWidth(0.05f, 0.05f);
        lr.SetVertexCount(13);
        update();
        lr.enabled = true;
       
    }

    internal void enable() {
        lr.enabled = true;
    }

    internal void disable() {
        lr.enabled = false;
    }

    internal void update() {

        lr.SetPosition(0, new Vector3(rect.renderer.bounds.min.x, rect.renderer.bounds.max.y, z_pos));
        lr.SetPosition(1, new Vector3(rect.renderer.bounds.max.x, rect.renderer.bounds.max.y, z_pos));
        lr.SetPosition(2, new Vector3(rect.renderer.bounds.min.x, rect.renderer.bounds.max.y, z_pos));
        lr.SetPosition(3, new Vector3(rect.renderer.bounds.max.x, rect.renderer.bounds.max.y, z_pos));

        lr.SetPosition(4, new Vector3(rect.renderer.bounds.max.x, rect.renderer.bounds.min.y, z_pos));
        lr.SetPosition(5, new Vector3(rect.renderer.bounds.max.x, rect.renderer.bounds.max.y, z_pos));
        lr.SetPosition(6, new Vector3(rect.renderer.bounds.max.x, rect.renderer.bounds.min.y, z_pos));

        lr.SetPosition(7, new Vector3(rect.renderer.bounds.min.x, rect.renderer.bounds.min.y, z_pos));
        lr.SetPosition(8, new Vector3(rect.renderer.bounds.max.x, rect.renderer.bounds.min.y, z_pos));
        lr.SetPosition(9, new Vector3(rect.renderer.bounds.min.x, rect.renderer.bounds.min.y, z_pos));


        lr.SetPosition(10, new Vector3(rect.renderer.bounds.min.x, rect.renderer.bounds.max.y, z_pos));     
        lr.SetPosition(11, new Vector3(rect.renderer.bounds.min.x, rect.renderer.bounds.min.y, z_pos));
        lr.SetPosition(12, new Vector3(rect.renderer.bounds.min.x, rect.renderer.bounds.max.y, z_pos));     
       
    }
}
