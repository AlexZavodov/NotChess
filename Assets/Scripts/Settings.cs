using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    #region singleton
    private static Settings _instance;

    public static Settings Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    [SerializeField] Text text;

    public string name_ { get; set; }
    public bool IsEnemyHuman { get; set; } = true;

    public void TextChanged()
    {
        name_ = text.text;
    }
}
