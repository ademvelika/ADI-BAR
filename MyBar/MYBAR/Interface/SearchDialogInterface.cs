using System;

namespace MYBAR.Interface
{
    public  interface SearchDialogInterface
    {
        bool HasTotal();
     
        dynamic getListItems(DateTime startdate,DateTime enddate, string word = "");
        bool DoubleClickEventFunction(object item);

    }
}
