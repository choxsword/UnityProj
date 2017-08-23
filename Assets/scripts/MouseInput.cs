using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {  
    private Vector3 targetPos;  
    protected   bool        m_bRaycastHit;  
    protected   const float m_fDefaultDistance  = 8.0f;  // 默认距离  
    protected   const float m_fDefaultWheelSpeed= 5.0f;   // 默认鼠标滚轮速度  
    public      float       m_fDistance         = m_fDefaultDistance;  
    public      float       m_fXSpeed           = 350.0f;    // X 方向速度  
    public      float       m_fYSpeed           = 300.0f;    // Y 方向速度  
    public      float       m_fWheelSpeed       = m_fDefaultWheelSpeed;  
      
    public      float       m_fYMinLimit        = -90f;  // Y轴最小旋转角度  
    public      float       m_fYMaxLimit        = 90f;   // Y轴最大旋转角度  
      
    private     float       m_fDistanceMin      = 0.10f;  
    private     float       m_fDistanceMax      = 500;  
      
    public      int         m_nMoveInputIndex   = 1;  //1对应右键   
    public      int         m_nRotInputIndex    = 0;  //0对应左键 ，， 2对应中键。  
      
    public      float       m_fXRot             = 0.0f;  // X轴旋转角度  
    public      float       m_fYRot             = 0.0f;  // Y轴旋转角度  
      
    protected   bool        m_bHandEnable       = true;  
    protected   Vector3     m_MovePostion;  
    protected   Vector3     m_OldMousePos;  
    protected   bool        m_bLeftClick;  
    protected   bool        m_bRightClick;  
      
    void OnEnable()  
    {  
        m_fDistance = PlayerPrefs.GetFloat("FxmTestMouse.m_fDistance", m_fDistance);  
        targetPos = Vector3.zero;  //m_TargetTrans.position;  
    }  
      
    void Start()  
    {  
        if (Camera.main == null) //摄像机为空返回  
            return;

        if (GetComponent<Rigidbody>())  
            GetComponent<Rigidbody>().freezeRotation= true; 
            
    }  
    bool IsGUIMousePosition()  
    {  
        Vector2 pos = GetGUIMousePosition();  //获取鼠标位置  
        if (new Rect(0, 0, Screen.width, Screen.height/10+30).Contains(pos))   //鼠标位置包含在 当前范围之内  
            return true;  
        if (new Rect(0, 0, 40, Screen.height).Contains(pos))  
            return true;  
        return false;  
    }  
      
    public static Vector2 GetGUIMousePosition()  //获取鼠标位置  
    {   
        return new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);   
    }  
      
    void Update()  
    {  
        if (IsGUIMousePosition() && (m_bLeftClick == false && m_bRightClick == false))  //如果鼠标不在范围内，并且没有点击鼠标左右键，返回  
            return;  
        if (Input.GetKey (KeyCode.LeftAlt))   
        {  
            UpdateCamera (false);  
        }  
    }  
      
    public void UpdateCamera(bool bOnlyZoom)    
    {  
        if (Camera.main == null)  //主摄像机为空返回  
            return;  
          
        if (m_fWheelSpeed < 0)  //设置滚轮速度  
            m_fWheelSpeed = m_fDefaultWheelSpeed;  
          
        float fDistRate     = m_fDistance / m_fDefaultDistance;  //计算、距离  
  
        float fOldDistance  = m_fDistance;  
          
        if (true)  //如果摄像机不为空  
        {  
            m_fDistance = Mathf.Clamp(m_fDistance - Input.GetAxis("Mouse ScrollWheel")*m_fWheelSpeed*fDistRate, m_fDistanceMin, m_fDistanceMax);  
              
            if (!bOnlyZoom && m_bRightClick && Input.GetMouseButton(m_nRotInputIndex))  //点击鼠标右键  
            {  
                m_fXRot += Input.GetAxis("Mouse X") * m_fXSpeed * 0.02f;// 计算X轴旋转  
                m_fYRot -= Input.GetAxis("Mouse Y") * m_fYSpeed * 0.02f;  //计算Y轴旋转  
            }  
              
            if (!bOnlyZoom && Input.GetMouseButtonDown(m_nRotInputIndex))  //确定是否按下鼠标右键  
                m_bRightClick   = true;  
            if (!bOnlyZoom && Input.GetMouseButtonUp(m_nRotInputIndex))  //当左键弹起时，设置右键无点击  
                m_bRightClick   = false;  
              
            m_fYRot = ClampAngle(m_fYRot, m_fYMinLimit, m_fYMaxLimit);      //计算旋转角度  
            Quaternion rotation = Quaternion.Euler(m_fYRot, m_fXRot, 0);  //转换旋转角度为  Quaternion  

            //通过距离实例化一个 距离位置  
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -m_fDistance);
            Vector3 position = rotation * negDistance + targetPos;

            Camera.main.transform.rotation = rotation;  //设置主摄像机的旋转  
            Camera.main.transform.position = position;  //设置主摄像机的位置  
            UpdatePosition(Camera.main.transform);
            // save  
            if (fOldDistance != m_fDistance)  //如果老的距离不等于新的距离，重新设置距离  
                PlayerPrefs.SetFloat("FxmTestMouse.m_fDistance", m_fDistance);
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    void UpdatePosition(Transform camera)
    {
        if (m_bHandEnable)
        {
            if (Input.GetMouseButtonDown(m_nMoveInputIndex))  //如果鼠标点击的 1键  
            {
                m_OldMousePos = Input.mousePosition;
                m_bLeftClick = true;
            }

            if (m_bLeftClick && Input.GetMouseButton(m_nMoveInputIndex))
            {
                Vector3 currMousePos = Input.mousePosition;
                float worldlen = GetWorldPerScreenPixel(targetPos);

                m_MovePostion += (m_OldMousePos - currMousePos) * worldlen;
                m_OldMousePos = currMousePos;
            }
            if (Input.GetMouseButtonUp(m_nMoveInputIndex))
                m_bLeftClick = false;
        }

        camera.Translate(m_MovePostion, Space.Self);
    }

    public static float GetWorldPerScreenPixel(Vector3 worldPoint)
    {
        Camera cam = Camera.main;
        if (cam == null)
            return 0;
        Plane nearPlane = new Plane(cam.transform.forward, cam.transform.position);
        float dist = nearPlane.GetDistanceToPoint(worldPoint);
        float sample = 100;
        return Vector3.Distance(cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 - sample / 2, dist)), cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 + sample / 2, dist))) / sample;
    }
}