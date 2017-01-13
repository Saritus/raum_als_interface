using System.Collections.Generic;

namespace TouchWalkthrough
{
    interface UIHandler
    {
        private List<Drop> allEvents { get; set; }

        public Drop[] getEvents();
        public Drop[] getFilteredEvents(Category[] filters);
        public Drop[] getFollowedEvents();

        public void showEvents();
        public void filter(Category[] filter);
        public void ignoreEvent(Drop ev);
        public void followEvent(Drop ev);
        public void showEventDetail(Drop ev);
    }
}