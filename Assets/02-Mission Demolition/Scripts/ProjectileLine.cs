using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static List<ProjectileLine> PROJ_LINES = new List<ProjectileLine>();
    private const float DIM_MULT = 0.75f;
    private LineRenderer line;
    private bool drawing=true;
    private Projectile projectile;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        line.SetPosition(0, transform.position);
        projectile = GetComponentInParent<Projectile>();
        AddLine(this);
    }

    private void FixedUpdate() {
        if (drawing)
        {
            line.positionCount++;
            line.SetPosition(line.positionCount-1, transform.position);
            if (projectile==null)
            {
                if (!projectile.awake)
                {
                    drawing=false;
                    projectile=null;
                }
            }
        }
    }

    static void AddLine(ProjectileLine line){
        Color col;
        foreach (var item in PROJ_LINES)
        {
            col = item.line.startColor;
            item.line.startColor = item.line.endColor = col;
        }
        PROJ_LINES.Add(line);
    }

    private void OnDestroy() {
        PROJ_LINES.Remove(this);
    }
}
