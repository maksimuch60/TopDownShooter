using System.Collections.Generic;
using TDS.Game.Objects.Patrol;
using UnityEditor;
using UnityEngine;

namespace TDS.Editor.Gizmos
{
    public class PatrolGizmoDrawer
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void DrawPatrolGizmo(PatrolPath patrolPath, GizmoType gizmoType)
        {
            if (Selection.activeGameObject == null)
            {
                return;
            }
            
            if (Selection.activeGameObject != patrolPath.transform.gameObject &&
                Selection.activeGameObject.gameObject.GetComponentInParent<PatrolPath>() == null)
            {
                return;
            }
            
            List<GameObject> pointList = patrolPath.GetPath();
            UnityEngine.Gizmos.color = Color.magenta;
            for (int i = 0; i < pointList.Count - 1; i++)
            {
                UnityEngine.Gizmos.DrawWireSphere(pointList[i].transform.position, 1);
                UnityEngine.Gizmos.DrawLine(pointList[i].transform.position, pointList[i + 1].transform.position);
            }

            UnityEngine.Gizmos.DrawWireSphere(pointList[^1].transform.position, 1);
            UnityEngine.Gizmos.DrawLine(pointList[^1].transform.position, pointList[0].transform.position);
        }
    }
}