using System.Collections.Generic;

namespace TouchWalkthrough
{
    interface UIHandler
    {
        List<Drop> allEvents { get; set; }

        Drop[] getEvents();
        Drop[] getFilteredEvents(Category[] filters);
        Drop[] getFollowedEvents();

        void showEvents();
        void filter(Category[] filter);
        void ignoreEvent(Drop ev);
        void followEvent(Drop ev);
        void showEventDetail(Drop ev);
    }
}