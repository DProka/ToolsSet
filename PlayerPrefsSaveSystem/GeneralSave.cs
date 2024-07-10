
public class GeneralSave
{
    public int count { get; private set; }
    public string name { get; private set; }

    private const string saveKey = "SaveKey";

    #region Variables

    public void SaveVariable(int a, string b)
    {
        count = a;
        name = b;

        Save();
    }

    #endregion

    #region Save Load

    public void ResetSave()
    {
        SaveData.GeneralData general = new SaveData.GeneralData();

        count = general._count;
        name = general._name;

        Save();
    }

    public void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
    }

    public void Load()
    {
        var data = SaveManager.Load<SaveData.GeneralData>(saveKey);

        count = data._count;
        name = data._name;
    }

    private SaveData.GeneralData GetSaveSnapshot()
    {
        SaveData.GeneralData data = new SaveData.GeneralData()
        {
            _count = count,
            _name = name,
        };

        return data;
    }
    #endregion
}
