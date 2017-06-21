namespace App.Security.Aggregate
{
    using System.Collections.Generic;
    public class Roles : List<Role>
    {
        public override string ToString()
        {
            string roleKeys = string.Empty;
            foreach (Role role in this)
            {
                roleKeys = string.IsNullOrWhiteSpace(roleKeys) ? role.Key : string.Format("{0},{1}", roleKeys, role.Key);
            }
            return roleKeys;
        }
    }
}
