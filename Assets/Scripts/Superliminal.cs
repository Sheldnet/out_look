using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superliminal : MonoBehaviour
{
  
    [Header("Components")]
    public Transform target;

    [Header("Parameters")]
    public LayerMask targetMask;
    public LayerMask ignoreTargetMask;
    public float offsetfactor; //Для хитбокса дабы не клипалось
    public AudioSource audio, audio2;

    float originalDistance;
    float originalScale;
    Vector3 targetScale;
    private float sensX, sensY;
    private float xRotation;
    private float yRotation;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xRotation = this.transform.rotation.x;
        
        HandleInput();
        ResizeTarget();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0)) //Если жмём левую кнопку мыши...
        {
            if (target==null) //Если нет подбираемого объекта, ищем что подобрать
            {
                RaycastHit hit; //Ищем мы raycast-ом.
                if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetMask))
                {
                    audio.Play();
                    target = hit.transform;
                    target.GetComponent<Rigidbody>().isKinematic = true;
                    originalDistance = Vector3.Distance(transform.position, target.position);
                    originalScale = target.localScale.x; //Тут сохранаяется только одно потому что подразумевается что у объекта scale будет одинаковый по всем осям. Если же нет, придётся это переписывать как вектор.
                    targetScale = target.localScale;
                }
            }
            else
            {
                if (xRotation < 30)
                {
                    audio2.Play();
                    target.GetComponent<Rigidbody>().isKinematic = false;
                    target = null;
                }
            }
        }
    }
    void ResizeTarget()
    {
        if (target==null) //Цель есть? Нет? Ну и вали отсюда.
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ignoreTargetMask))
        {
            target.position = hit.point - transform.forward * offsetfactor * targetScale.x; //Offsetfactor здесь чтоб предмет не клипался. Из объяснения это далеко не идеально: клипаться чуть будет, + не дружит с углами стен. Понятия не имею как это исправить но в будущем к концу всего этого надо будет.

            float currentDistance = Vector3.Distance(transform.position, target.position);
            float s = currentDistance / originalDistance;
            targetScale.x = targetScale.y = targetScale.z = s;

            target.localScale = targetScale * originalScale;
        }
    }
}
