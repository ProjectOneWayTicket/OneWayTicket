using UnityEngine;
using System.Collections;
using PACE.Framework;
using Enums;
using GamePlay.Interactable;

public class PlayerCamera : BaseBehaviour
{
    Ray ray;
    RaycastHit hit;
    string _label = "";
    public Transform targetTransform;
    private ILocalizationController localizationController;
    private SelectedInteractable selectedInteractable;

    protected class SelectedInteractable
    {
        GameObject _gameObject;
        IInteractable _interactable;
        Point _selectedPoint;
        public SelectedInteractable(GameObject gameObject)
        {
            _gameObject = gameObject;
            _interactable = gameObject.GetComponent<IInteractable>();
            _selectedPoint = new Point(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        }
        public GameObject GetGameObject() { return _gameObject; }
        public IInteractable GetInteractable() { return _interactable; }
        public Point GetSelectedPoint() { return _selectedPoint; }
    }

    void Start ()
    {
        localizationController = new LocalizationController();
    }

	void Update ()
    {
        //_label = "";

        //LayerMask noObstacleLayerMask = LayerMaskExtensions.LayerMaskExcludingLayers(Layer.NavObstacles);

        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, 1000, noObstacleLayerMask))
        //{
        //    if(hit.collider && hit.collider.gameObject.GetComponent<IInteractable>() != null)
        //    {
        //        _label = hit.collider.gameObject.GetComponent<IInteractable>().GetLabel();
        //    }
        //}

        //if (Input.GetButtonDown("RightMouseButton"))
        //{
        //    if (selectedInteractable != null)
        //        selectedInteractable = null;
        //    else
        //    {
        //        selectedInteractable = null;
        //        if (hit.collider && hit.collider.gameObject.GetComponent<IInteractable>() != null)
        //        {
        //            if (hit.collider.gameObject.GetComponent<IInteractable>().IsActive())
        //                selectedInteractable = new SelectedInteractable(hit.collider.gameObject);
        //        }
        //    }
        //}

    }

    //void OnGUI()
    //{
    //    //if (!_label.IsNullOrEmpty())
    //    //   GUI.Button(new Rect(Screen.width / 2 - 500, Screen.height - 100, 1000, 100), _label);
    //    //if (selectedInteractable != null)
    //    //{
    //    //    GUI.Button(new Rect((float)selectedInteractable.GetSelectedPoint().x - 25, (float)selectedInteractable.GetSelectedPoint().y - 25, 50, 50), selectedInteractable.GetInteractable().GetLabel());
    //    //    if (selectedInteractable.GetInteractable().CanLook())
    //    //        if (GUI.Button(new Rect((float)selectedInteractable.GetSelectedPoint().x + 50, (float)selectedInteractable.GetSelectedPoint().y - 25, 200, 50), "String_LookAt{0}".Localize(selectedInteractable.GetInteractable().GetLabel())))
    //    //            selectedInteractable.GetInteractable().Look();
    //    //}
    //    //else if (!_label.IsNullOrEmpty())
    //    //    GUI.Button(new Rect(Event.current.mousePosition.x - 100, Event.current.mousePosition.y - 100, 200, 100), _label);


    //    //if (GUI.Button(new Rect(0, Screen.height - 100, 100, 50), "English"))
    //    //    localizationController.SetLanguage("en");
    //    //if (GUI.Button(new Rect(0, Screen.height - 50, 100, 50), "French"))
    //    //    localizationController.SetLanguage("fr");


    //}
}
