using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    LineRenderer LR;

    [SerializeField]
    Joystick AttackJoystick;

    [SerializeField]
    Transform AttackLookAtPoint;

    [SerializeField]
    public float TrailDistance;

    [SerializeField]
    Transform Player;

    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        if (AttackJoystick.Horizontal > 0 || AttackJoystick.Horizontal < 0 || AttackJoystick.Vertical > 0 || AttackJoystick.Vertical < 0)
        {
            if (LR.gameObject.activeInHierarchy == false)
            {
                LR.gameObject.SetActive(true);
            }

            //transform.position = new Vector3(Player.position.x, 0.5f, Player.position.z);

            AttackLookAtPoint.position = new Vector3(AttackJoystick.Horizontal + Player.position.x, 0.5f, AttackJoystick.Vertical + Player.position.z);

            transform.LookAt(new Vector3(AttackLookAtPoint.position.x, 0.5f, AttackLookAtPoint.position.z));

            if (Physics.Raycast(transform.position, transform.forward, out hit, TrailDistance))
            {
                LR.SetPosition(1, hit.point);
            }
            else
            {
                LR.SetPosition(1, transform.forward * TrailDistance);
                LR.SetPosition(1, new Vector3(LR.GetPosition(1).x, LR.GetPosition(1).y, LR.GetPosition(1).z));
            }
        }
        else
        {
            LR.gameObject.SetActive(false);
        }
    }
}
