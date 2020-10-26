using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler {
    public Canvas Padre;
    public float radio;
    private Vector2 Axis;

    public Vector2 axis {
        get {
            return Axis;
        }
    }

    public float Horizontal {
        get {
            return Axis.x;
        }
    }

    public float Vertical {
        get {
            return Axis.y;
        }
    }
    public bool isMoving {
        get {
            return Axis != Vector2.zero;
        }
    }

    Vector3 PosInicial;
    private void Start() {
        PosInicial = transform.position;
    }

    public void OnDrag(PointerEventData point) {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Padre.transform as RectTransform, point.position, Padre.worldCamera, out pos);
        Vector3 newpos = Padre.transform.TransformPoint(pos) - PosInicial;
        newpos.x = Mathf.Clamp(newpos.x, -radio, radio);
        newpos.y = Mathf.Clamp(newpos.y, -radio, radio);

        Axis = newpos / radio;

        transform.localPosition = newpos;
    }

    public void OnEndDrag(PointerEventData point) {
        transform.position = PosInicial;
        Axis = Vector2.zero;
    }
}