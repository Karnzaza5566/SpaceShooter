using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;//ตัวแปรสำหรับนำจุด waypoint มาใส่
    [SerializeField] private float _speed;//ความเร็วในการเคลื่อนที่ระหว่าง waypoint
    [SerializeField] private float _checkDistance = 0.05f;//เช็คระยะห่าง

    private Transform _targetWaypoint;//วัตถุที่เชื่อมกับ waypoint
    private int _currentWaypointIndex = 0;//ตำแหน่งปัจจุบัน

    void Start()
    {
        _targetWaypoint = _waypoints[0];//การเคลื่อนที่ของ วัตถุ ตำแหน่งแรกมีค่าเท่ากับ 0
    }

    void Update()
    {
        transform.position = (Vector3)Vector2.MoveTowards(//การเคลื่อนที่
            current:(Vector2)transform.position,//การเคลื่อนที่จุดปัจจุบัน
            (Vector2)_targetWaypoint.position,//การเคลื่อนที่ของวัตถุ
            maxDistanceDelta:_speed * Time.deltaTime);//ระยะห่างเคลื่อนที่ด้วยเวลา

        if(Vector2.Distance(a:transform.position, b:_targetWaypoint.position) < _checkDistance)//ถ้าหากจุด a และจุด b มีค่าน้อยกว่าค่าเช็คระยะห่าง
        {
            _targetWaypoint = GetNextWaypoint();//จะทำการย้ายวัตถุไปยัง waypoint ถัดไป
        }
    }

    private Transform GetNextWaypoint()//คำสั่งการเคลื่อนที่ของวัตถุ
    {
        _currentWaypointIndex++;// เพิ่มค่าของตัวแปรเก็บลำดับของ Waypoint ไปอีก 1 หน่วย เพื่อเลือก Waypoint ถัดไปในเส้นทาง
        if (_currentWaypointIndex >= _waypoints.Length)//ถ้าหาก waypoint ปัจจุบันมีค่ามากกว่าหรือเท่ากับจำนวนของ Waypoints ทั้งหมด
        {
            _currentWaypointIndex = 0;//กำหนดค่า Waypoint ปัจจุบันเป็น 0
        }
        return _waypoints[_currentWaypointIndex];//คืนค่า Waypoint Waypoint เพื่อนำไปใช้ในการเคลื่อนที่ถัดไปของอ็อบเจ็กต์.
    }
}
