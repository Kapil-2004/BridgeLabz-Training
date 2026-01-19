class CustomDictionary
{
    private int[] keys;
    private string[] values;
    private int count;

    public CustomDictionary(int size)
    {
        keys = new int[size];
        values = new string[size];
        count = 0;
    }

    public void Add(int key, string value)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i] == key)
            {
                values[i] = value; // update
                return;
            }
        }

        keys[count] = key;
        values[count] = value;
        count++;
    }

    public bool ContainsKey(int key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i] == key)
                return true;
        }
        return false;
    }

    public string Get(int key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i] == key)
                return values[i];
        }
        return null;
    }

    public int Count()
    {
        return count;
    }

    public int GetKeyAt(int index)
    {
        return keys[index];
    }

    public string GetValueAt(int index)
    {
        return values[index];
    }
}
