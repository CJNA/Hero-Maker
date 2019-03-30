// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControl.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class PlayerControl : InputActionAssetReference
{
    public PlayerControl()
    {
    }
    public PlayerControl(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_escape = m_Player.GetAction("escape");
        m_Player_Seek = m_Player.GetAction("Seek");
        m_Player_Flee = m_Player.GetAction("Flee");
        m_Player_FleeItem = m_Player.GetAction("FleeItem");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        if (m_PlayerActionsCallbackInterface != null)
        {
            Player.SetCallbacks(null);
        }
        m_Player = null;
        m_Player_escape = null;
        m_Player_Seek = null;
        m_Player_Flee = null;
        m_Player_FleeItem = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        var PlayerCallbacks = m_PlayerActionsCallbackInterface;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
        Player.SetCallbacks(PlayerCallbacks);
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player
    private InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private InputAction m_Player_escape;
    private InputAction m_Player_Seek;
    private InputAction m_Player_Flee;
    private InputAction m_Player_FleeItem;
    public struct PlayerActions
    {
        private PlayerControl m_Wrapper;
        public PlayerActions(PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @escape { get { return m_Wrapper.m_Player_escape; } }
        public InputAction @Seek { get { return m_Wrapper.m_Player_Seek; } }
        public InputAction @Flee { get { return m_Wrapper.m_Player_Flee; } }
        public InputAction @FleeItem { get { return m_Wrapper.m_Player_FleeItem; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                escape.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                escape.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                escape.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                Seek.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSeek;
                Seek.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSeek;
                Seek.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSeek;
                Flee.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlee;
                Flee.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlee;
                Flee.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlee;
                FleeItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFleeItem;
                FleeItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFleeItem;
                FleeItem.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFleeItem;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                escape.started += instance.OnEscape;
                escape.performed += instance.OnEscape;
                escape.cancelled += instance.OnEscape;
                Seek.started += instance.OnSeek;
                Seek.performed += instance.OnSeek;
                Seek.cancelled += instance.OnSeek;
                Flee.started += instance.OnFlee;
                Flee.performed += instance.OnFlee;
                Flee.cancelled += instance.OnFlee;
                FleeItem.started += instance.OnFleeItem;
                FleeItem.performed += instance.OnFleeItem;
                FleeItem.cancelled += instance.OnFleeItem;
            }
        }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
}
public interface IPlayerActions
{
    void OnEscape(InputAction.CallbackContext context);
    void OnSeek(InputAction.CallbackContext context);
    void OnFlee(InputAction.CallbackContext context);
    void OnFleeItem(InputAction.CallbackContext context);
}
