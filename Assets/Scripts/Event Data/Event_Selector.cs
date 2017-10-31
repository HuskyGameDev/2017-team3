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
        Random rnd = new Random();
        int selection = Random.Range(0, choices.Count);
        Event chosen = choices[selection];
        choices.Remove(chosen);
        foreach(Event e in chosen.getNextEvents())
        {
            choices.Add(e);
        }
        return chosen;
    }
}
