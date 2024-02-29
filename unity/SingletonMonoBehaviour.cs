/* 
 * Unity用のSingletonMonoBehaviourのサンプルプログラムです。
 * 詳細は https://unixo-lab.com/unity/singleton.html をご覧下さい。
 */
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    public static T Instance { get; private set; }
    protected SingletonMonoBehaviour() { }
    protected void Awake() => Instance = (T)this;
}
