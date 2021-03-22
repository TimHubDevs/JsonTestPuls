using System;
using System.Collections.Generic;

public class NavigationSystem
{
    private static List<Action> needToClose = new List<Action>();

    public static void closeAll()
    {
        foreach (var action in needToClose)
        {
            action.Invoke();
        }

        needToClose.Clear();
    }

    public static void addActionForClose(Action action)
    {
        needToClose.Add(action);
    }
}