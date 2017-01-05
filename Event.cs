using System;

public class Event 
{
    public String name { get; set; }
    public Location pos { get; set; }
    public Time start { get; set; }

    public Event()
	{
	}

    public bool saveToFile(String filename)
    {
        return true;
    }
}
