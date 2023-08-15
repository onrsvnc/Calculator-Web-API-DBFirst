using System;

namespace Calc.Models;

public class TodoItem
{
	public TodoItem()
	{
	}

    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsComplete { get; set; }
}
