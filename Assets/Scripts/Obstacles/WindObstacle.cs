using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindObstacle : ObstacleBehaviour
{
    AreaEffector2D areaEffector;

    private void Start()
    {
        areaEffector = GetComponent<AreaEffector2D>();
    }
    private void Update()
    {
        if (isTriggered)
        {
            EnableObstacle();
        }
        else {
            DisableObstacle();
        }
    }
    public override void DisableObstacle()
    {
        areaEffector.enabled = false;
    }

    public override void EnableObstacle()
    {
        areaEffector.enabled = true;
    }
}
