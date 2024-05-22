using System.Collections.Generic;

class Room
{
    private string description;
    private Dictionary<string, Room> exits;
    private List<string> items;
    private List<string> objects;

    public Room(string desc)
    {
        description = desc;
        exits = new Dictionary<string, Room>();
        items = new List<string>();
        objects = new List<string>();

    }

    public void AddExit(string direction, Room neighbor)
    {
        exits.Add(direction, neighbor);
    }


    public void AddItem(string item)
    {
        items.Add(item);
    }
    public void AddObject(string item)
    {
        objects.Add(item);
    }
    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    public void RemoveItem(string item)
    {
        items.Remove(item);
    }
    public bool contains(string item)
    {
        return objects.Contains(item);
    }
    public void removeObject(string chest)
    {
        objects.Remove(chest);
    }
    public string GetShortDescription()
    {
        return description;
    }
    public string GetLongDescription3()
    {
        string str = "";
        str = GetExitString();
        return str;
    }
    public string GetExits()
    {
        string str = "";
        str += GetExitString();
        return str;
    }
    public string GetLongDescription()
    {
        string str = "You are ";
        str += description;
        str += ".\n";
        return str;
    }
    public string GetLongDescription2()
    {
        string str = "";
        str += GetItemString();
        return str;
    }
    public string GetLongDescription5()
    {
        string str = "";
        str += GetObjectString();
        return str;
    }
    public Room GetExit(string direction)
    {
        if (exits.ContainsKey(direction))
        {
            return exits[direction];
        }
        return null;
    }

    private string GetExitString()
    {
        string str = "Exits:";
        int countCommas = 0;
        foreach (string key in exits.Keys)
        {
            if (countCommas != 0)
            {
                str += ",";
            }
            str += " " + key;
            countCommas++;
        }
        return str;
    }
    private string GetObjectString()
    {
        string str = "Object:";
        if (objects.Count == 0)
        {
            str = "";
            return str;
        }


        int countCommas = 0;

        foreach (string item in objects)
        {
            if (countCommas != 0)
            {
                str += ",";
            }
            str += " " + item;
            countCommas++;
        }
        return str;
    }
    private string GetItemString()
    {
        string str = "Items:";
        if (items.Count == 0)
        {
            str = "";
            return str;
        }


        int countCommas = 0;

        foreach (string item in items)
        {
            if (countCommas != 0)
            {
                str += ",";
            }
            str += " " + item;
            countCommas++;
        }
        return str;
    }
}