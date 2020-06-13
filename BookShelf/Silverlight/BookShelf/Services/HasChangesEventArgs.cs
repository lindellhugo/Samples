using System;

namespace BookShelf
{
    public class HasChangesEventArgs : EventArgs
    {
        public bool HasChanges { get; set; }
    }
}