using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSelector {

	public Event getEvent(Player p)
    {
        List<Event> choices = p.CurrentEvents;
        if (choices.Count == 0)
        {
            return null;
        }
        int total = 0;
        foreach (Event e in choices)
        {
            total += e.getWeight(p);
        }
        int selection = Random.Range(0, total);
        Event chosen=null;
        foreach (Event e in choices)
        {
            selection -= e.getWeight(p);
            if (selection <= 0)
            {
                chosen = e;
                break;
            }
        }
        choices.Remove(chosen);
        foreach(Event e in chosen.getNextEvents())
        {
            p.CurrentEvents.Add(e);
        }
        return chosen;
    }
}
