using System;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public class Activity
    {
        public string Description;
        public string Reducing;
        public string Accepting;
        public string Avoiding;
        public string Transferring;

        public Activity(string description)
        {
            Description = description;
        }
    }
}