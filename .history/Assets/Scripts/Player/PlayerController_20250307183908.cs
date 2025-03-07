using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject WinUI;
    [SerializeField] GameObject DefeatUI;
    [SerializeField] GameObject BlockBorder;
    [SerializeField] GameObject EnhanceCompleteUI;
    [SerializeField] GameObject RequireGoldUI;

    [SerializeField] TextMeshProUGUI Text_Gold;
    [SerializeField] TextMeshProUGUI Text_HP;

    [SerializeField] ParticleSystem DefeatVFX;

    Camera PlayerCamera;
    GameObject LastClickUI;

    int StageNum;
    int StageGold;
    int StageHP;

    bool bDefeat = false;
    bool bDragMove = true;
    bool bCameraSticky = false;

    public int stageNum {get {return StageNum;} set {StageNum = value;}}
    public int stageGold {get {return StageGold;}}
    public bool DragMove {get {return bDragMove;} set {bDragMove = value;}}
    public bool CameraSticky {get {return bCameraSticky;} set {bCameraSticky = value;}}
     
    void Start()
    {
        PlayerCamera = Camera.main;
        Time.timeScale = GameManager.Instance.stageTimeScale;

        UpdateStageData();
        UpdateGoldText();
        UpdatePlayerHPText();
    }

    void UpdateStageData()
    {
        var stageData = GameManager.Instance.GetStageData;

        StageHP = stageData[stageNum].StageHP;
        StageGold = stageData[stageNum].StageGold;
    }

    void UpdateGoldText()
    {
        Text_Gold.text = "Gold : "+ StageGold.ToString();
    }

    void UpdatePlayerHPText()
    {
        Text_HP.text = "HP : "+ StageHP.ToString();
    }

    public void UpdateGold(int GoldAmount)
    {
        StageGold = Mathf.Max(0, StageGold + GoldAmount);
        UpdateGoldText();
    }

    public void TakeDamage(int DamageAmount)
    {
        StageHP = Mathf.Max(0, StageHP - DamageAmount);
        UpdatePlayerHPText();

        if(StageHP == 0) 
        {
            bDefeat = true;
            BlockClick(true);
            DefeatVFX.Play();
            Invoke("DisplayDefeatUI", 3.0f);
        }
    }

    void DisplayDefeatUI()
    {
        Time.timeScale = 0;
        DefeatUI.SetActive(true);  
    }

    public void DisplayWinUI()
    {
        if(bDefeat) return;
        
        Time.timeScale = 0;
        WinUI.SetActive(true);

        GameManager.Instance.OpenNextStage(StageNum + 1);

        BlockClick(true);
    }

    public void BlockClick(bool bBlock)
    {
        BlockBorder.SetActive(bBlock);
    }

    public void DisplayEnhanceCompleteUI()
    {
        EnhanceCompleteUI.SetActive(true);
    }

    public void DisplayRequireGoldUI()
    {
        RequireGoldUI.SetActive(true);
    }

    public void CloseLastClickUI(GameObject ClickUI = null)
    {
        if(LastClickUI) LastClickUI.SetActive(false);

        LastClickUI = ClickUI;
    }
    
    public void MoveCamera(Vector3 newPos)
    {
        if(!DragMove || bCameraSticky) return;

        Vector3 movePos = PlayerCamera.transform.position;
        movePos -= Vector3.ClampMagnitude(new Vector3(newPos.x, 0.0f, newPos.y), 0.15f);
        // movePos = Vector3.Lerp(movePos, new Vector3(newPos.x, movePos.y, newPos.z), 0.1f);
        PlayerCamera.transform.position = movePos;
    }
}
