using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleton
{
    void Init();
}

public abstract class NonUnitySingleton<T> : ISingleton where T : NonUnitySingleton<T>, new()
{
    public abstract void Init();

    private static T _instance;

    public static T Instance => _instance != null ? _instance : GetInstanceObject();

    protected static T GetInstanceObject()
    {
        if (_instance != null) return _instance;

        _instance = new T();

        var _singleton = _instance as NonUnitySingleton<T>;

        _singleton.Init();
        return _instance;
    }
}

public abstract class Singleton<T> : MonoBehaviour, ISingleton where T : Singleton<T>
{
    /// <summary>
    /// 싱글톤에서 초기화를 해야 할 부분을 적어둠
    /// awake에서 실행하게 했음
    /// </summary>
    public abstract void Init();
    public static bool IsNull => _instance == null;

    private static T _instance;

    public static T Instance => !IsNull ? _instance : GetInstanceObject();

    /// <summary>
    /// 싱글톤을 만들어주고 instance 반환하는 함수
    /// awake에서 실행되게 하였으며 있을경우 재실행 안됨
    /// </summary>
    protected static T GetInstanceObject()
    {
        if (!IsNull) return _instance;
        _instance = FindObjectOfType<T>();
        var _singleton = _instance as Singleton<T>;
        _singleton.Init();

        return _instance;
    }

    protected void Awake()
    {
        _instance = GetInstanceObject();
    }

}