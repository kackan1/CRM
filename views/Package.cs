using System;

namespace CRM2.Views
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        private string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public decimal Hours { get; set; }
        public string Type { get; set; }
        public bool Archived { get; set; }
        public Package()
        {
        }
        public override string ToString()
        {
            return $"{Id} {Name} {Client} {ValidFrom} {ValidTo}" ;
        }

        public string GetValidFrom()
        {
            return ValidFrom;
        }

        public void SetValidFrom(string validFrom)
        {
            ValidFrom = validFrom;
        }
    }
}