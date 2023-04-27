using JetBrains.Annotations;
using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;

//[ExecuteInEditMode]
public class AroundBall : MonoBehaviour
{
    // Rotation Direction
    // CW: Clockwise
    // CCW: Counter Clockwise
    private enum ERotDir { CW, CCW }
    private enum ERotType { Pitch, Yaw, Roll }

    #region Public Variables
    [Header("- Game Objects -")]
    [SerializeField]
    private GameObject ballPrefab = null;
    [SerializeField]
    private Transform targetTr = null;

    [Header("- Values -")]
    [SerializeField, Range(0f, 300f)]
    private float speed = 100f;
    [SerializeField, Range(0f, 10f)]
    private float distance = 1f;    // Radius

    [Header("- Type -")]
    [SerializeField]
    private ERotDir rotDir = ERotDir.CCW;
    [SerializeField]
    private ERotType rotType = ERotType.Yaw;
    #endregion


    private Transform ballTr = null;

    private float angle = 0f;

    public class TestClass {
        public int i;
    }
    public struct TestStruct {
        public int i;
    }
    private void Test()
    {
        TestClass tc = new TestClass();
        tc.i = 1;
        TestClass cpyClass = tc;
        cpyClass.i = 10;
        Debug.Log("tc.i: " + tc.i);

        TestStruct ts = new TestStruct();
        ts.i = 1;
        TestStruct cpyStruct = ts;
        cpyStruct.i = 10;
        Debug.Log("ts.i: " + ts.i);
    }

    private void Awake()
    {
        //Test();

        //ballTr = transform.GetChild(0);
        //Debug.Log(ballTr.name);
        if (ballPrefab == null)
        {
            Debug.LogError("ballPrefab is missing!");
            return;
        }

        GameObject go = Instantiate(ballPrefab);
        //go.transform.parent = transform;
        go.transform.SetParent(transform);
        ballTr = go.transform;
    }

    private void Update()
    {
        if (targetTr == null) return;

        // Clamp
        switch (rotDir)
        {
            case ERotDir.CW:
                angle -= Time.deltaTime * speed;
                if (angle < 0f) angle = 360f;
                break;
            case ERotDir.CCW:
                angle += Time.deltaTime * speed;
                if (angle > 360f) angle = 0f;
                break;
        }
        

        Vector3 anglePos = new Vector3();
        CalcAnglePosWithRotType(
            rotType, angle, ref anglePos);

        Vector3 targetPos = targetTr.position;
        ballTr.position =
            targetPos + (anglePos * distance);
    }

    private void CalcAnglePosWithRotType(
        ERotType _rotType,
        float _angle,
        ref Vector3 _pos)
    {
        float angle2Rad = _angle * Mathf.Deg2Rad;
        switch(_rotType)
        {
            case ERotType.Pitch:
                _pos.x = 0f;
                _pos.y = Mathf.Sin(angle2Rad);
                _pos.z = Mathf.Cos(angle2Rad);
                break;
            case ERotType.Yaw:
                _pos.x = Mathf.Cos(angle2Rad);
                _pos.y = 0f;
                _pos.z = Mathf.Sin(angle2Rad);
                break;
            case ERotType.Roll:
                _pos.x = Mathf.Cos(angle2Rad);
                _pos.y = Mathf.Sin(angle2Rad);
                _pos.z = 0f;
                break;
        }
    }
}
