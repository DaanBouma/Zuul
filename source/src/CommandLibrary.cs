using System.Collections.Generic;

class CommandLibrary
{
	private readonly List<string> validCommands;
	public CommandLibrary()
	{
		validCommands = new List<string>();

		validCommands.Add("help");
		validCommands.Add("go");
		validCommands.Add("quit");
		validCommands.Add("status");
		validCommands.Add("take");
        validCommands.Add("look");
        validCommands.Add("drop");
        validCommands.Add("search");
        validCommands.Add("use");
        validCommands.Add("open");
        validCommands.Add("attack");
        validCommands.Add("stats");
        validCommands.Add("weight");
    }
	public bool IsValidCommandWord(string instring)
	{
		for (int i = 0; i < validCommands.Count; i++)
		{
			if (validCommands[i] == instring)
			{
				return true;
			}
		}
		return false;
	}
	public string GetCommandsString()
	{
		string str = "";
		for (int i = 0; i < validCommands.Count; i++)
		{
			str += validCommands[i];
			if (i < validCommands.Count - 1)
			{
				str += ", ";
			}
		}
		return str;
	}
}
