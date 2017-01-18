using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TouchWalkthrough
{
    interface iUIHandler{
        //Development functions
        List<Drop> createDummyDrops(int i);

        //filterung geht effizienter: List<Drop> filteredEvents; laden bei filterdruck neue elemnte in die liste oder entfernen alte
        List<Drop> getDrops();
        List<Drop> getDrops(Category[] filters);
        List<Drop> getFollowedDrops();
        Drop getDrop(int i);
        void ignoreDrop(Drop d);
        void followDrop(Drop d);

        //client-server communication
        void updateDropList(DateTime lastTimestamp);
        //Julians datentyp
        string getImage(string path);


        // Front-End Funktionen
	    void showDrop();
	    void showDropDetail(Drop ev);
    }
}